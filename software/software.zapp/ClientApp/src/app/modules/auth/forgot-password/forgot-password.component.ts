import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { fuseAnimations } from '@fuse/animations';
import { FuseAlertType } from '@fuse/components/alert';
import { AuthService } from 'app/core/auth/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'auth-forgot-password',
    templateUrl: './forgot-password.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
})
export class AuthForgotPasswordComponent implements OnInit {
    @ViewChild('forgotPasswordNgForm') forgotPasswordNgForm: NgForm;

    alert: { type: FuseAlertType; message: string } = {
        type: 'success',
        message: '',
    };
    showAlert: boolean = false;
    public record: any = {
        email: '',
        captcha: '',
    };
    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        private _router: Router,
        private _formBuilder: FormBuilder
    ) {}

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this.realoadCapcha();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Send the reset link
     */
    loading: boolean = false;
    srcCaptcha: any;
    realoadCapcha() {
        var d = new Date();
        var n = d.getTime();
        this.srcCaptcha = '/CaptCha/GetCaptChaImage?' + n;
    }
    errorModel: any;
    sendResetLink(): void {
        // Hide the alert
        this.showAlert = false;
        this.loading = true;
        // Forgot password
        this._authService
            .forgotPassword(this.record.email, this.record.captcha)
            .pipe(
                finalize(() => {
                    // Show the alert
                    this.showAlert = true;
                    this.loading = false;
                })
            )
            .subscribe(
                (response) => {
                    this.loading = false;
                    // Navigate to the sign-in required page
                    this._router.navigateByUrl('/sign-in');
                    // Set the alert
                    this.alert = {
                        type: 'success',
                        message:
                            "Password reset sent! You'll receive an email if you are registered on our system.",
                    };
                },
                (error) => {
                    if (error.status === 400) {
                        this.errorModel = error.error;
                    }
                    this.loading = false;
                    // Show the alert
                    this.showAlert = true;
                    // Set the alert
                    this.alert = {
                        type: 'error',
                        message:
                            'Email does not found! Are you sure you are already a member?',
                    };
                }
            );
    }
}
