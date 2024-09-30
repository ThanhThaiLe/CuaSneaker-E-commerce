import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { fuseAnimations } from '@fuse/animations';
import { FuseValidators } from '@fuse/validators';
import { FuseAlertType } from '@fuse/components/alert';
import { AuthService } from 'app/core/auth/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'auth-reset-password',
    templateUrl: './reset-password.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
})
export class AuthResetPasswordComponent implements OnInit {
    @ViewChild('resetPasswordNgForm') resetPasswordNgForm: NgForm;

    alert: { type: FuseAlertType; message: string } = {
        type: 'success',
        message: '',
    };
    resetPasswordForm: FormGroup;
    showAlert: boolean = false;
    iduser: string = '';
    token: string = '';
    errorModel: any = [];
    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        private _formBuilder: FormBuilder,
        private _router: Router,
        public _http: HttpClient,
        public route: ActivatedRoute
    ) {
        try {
            this.token = this.route.snapshot.queryParamMap.get('token');
            this._http
                .post('sys_user.ctr/checkResetPass/', {
                    token: this.token,
                })
                .subscribe(
                    (resp) => {
                        if (resp == false) {
                            this._router.navigate(['/sign-in']);
                        } else {
                            this.iduser = resp as any;
                        }
                    },
                    (error) => {
                        this._router.navigate(['/sign-in']);
                    }
                );
        } catch {
            this._router.navigate(['/sign-in']);
        }
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        // Create the form
        this.resetPasswordForm = this._formBuilder.group(
            {
                password: ['', Validators.required, Validators.minLength(8)],
                passwordConfirm: [
                    '',
                    Validators.required,
                    Validators.minLength(8),
                ],
            },
            {
                validators: FuseValidators.mustMatch(
                    'password',
                    'passwordConfirm'
                ),
            }
        );
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Reset password
     */
    resetPassword(): void {
        // Return if the form is invalid
        if (this.resetPasswordForm.invalid) {
            return;
        }

        // Disable the form
        this.resetPasswordForm.disable();

        // Hide the alert
        this.showAlert = false;

        // Send the request to the server
        this._authService
            .resetPassword(
                this.resetPasswordForm.get('password').value,
                this.resetPasswordForm.get('passwordConfirm').value,
                this.iduser
            )
            .pipe(
                finalize(() => {
                    // Re-enable the form
                    this.resetPasswordForm.enable();

                    // Reset the form
                    this.resetPasswordNgForm.resetForm();

                    // Show the alert
                    this.showAlert = true;
                })
            )
            .subscribe(
                (response) => {
                    this._router.navigateByUrl('/signed-in-redirect');
                },
                (error) => {
                    if (error.status === 400) {
                        this.errorModel = error.error;
                    }
                }
            );
    }
}
