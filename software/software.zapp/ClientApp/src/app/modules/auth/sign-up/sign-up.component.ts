import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseAlertType } from '@fuse/components/alert';
import { AuthService } from 'app/core/auth/auth.service';

@Component({
    selector: 'auth-sign-up',
    templateUrl: './sign-up.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
})
export class AuthSignUpComponent implements OnInit {
    @ViewChild('signUpNgForm') signUpNgForm: NgForm;

    alert: { type: FuseAlertType; message: string } = {
        type: 'success',
        message: '',
    };
    showAlert: boolean = false;
    public record: any = {
        last_name: '',
        first_name: '',
        email: '',
        password: '',
        captcha: '',
        agreements: false,
    };
    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        private _formBuilder: FormBuilder,
        private _router: Router
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
     * Sign up
     */
    loading: boolean = false;
    srcCaptcha: any;
    realoadCapcha() {
        var d = new Date();
        var n = d.getTime();
        this.srcCaptcha = '/CaptCha/GetCaptChaImage?' + n;
    }
    errorModel: any;
    signUp(): void {
        // Hide the alert
        this.showAlert = false;
        // Sign up
        this._authService.signUp(this.record).subscribe(
            (response) => {
                this.loading = true;
                // Navigate to the confirmation required page
                this._router.navigateByUrl('/confirmation-required');
            },
            (error) => {
                if (error.status === 400) {
                    this.errorModel = error.error;
                }
                // Set the alert
                this.alert = {
                    type: 'error',
                    message: 'Something went wrong, please try again.',
                };

                this.loading = false;
                // Show the alert
                this.showAlert = true;
            }
        );
    }
}
