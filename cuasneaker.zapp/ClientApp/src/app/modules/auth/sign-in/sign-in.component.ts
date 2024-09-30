import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { fuseAnimations } from '@fuse/animations';
import { FuseAlertType } from '@fuse/components/alert';
import { AuthService } from 'app/core/auth/auth.service';

@Component({
    selector: 'auth-sign-in',
    templateUrl: './sign-in.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations,
})
export class AuthSignInComponent implements OnInit {
    @ViewChild('signInNgForm') signInNgForm: NgForm;

    alert: { type: FuseAlertType; message: string } = {
        type: 'success',
        message: '',
    };
    private showAlert: boolean = false;
    private false_login: any = 0;
    public record: any = {
        email: '',
        password: '',
        captcha: '',
        show_captcha: 0,
    };
    /**
     * Constructor
     */
    constructor(private _authService: AuthService, private _router: Router) {}

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this.realoadCapcha();
        // Create the form
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Sign in
     */
    loading: boolean = false;
    srcCaptcha: any;
    realoadCapcha() {
        var d = new Date();
        var n = d.getTime();
        this.srcCaptcha = '/CaptCha/GetCaptChaImage?' + n;
    }
    errorModel: any;
    signInNew(): void {
        this.loading = true;
        this._authService.signInNew(this.record).subscribe(
            (resp) => {
                this._router.navigateByUrl('/signed-in-redirect');
            },
            (error) => {
                if (error.status === 400) {
                    this.errorModel = error.error;
                }
                this.false_login++;
                if (this.false_login == 3) this.record.show_captcha = 1;
                this.showAlert = true;
                this.alert = {
                    type: 'error',
                    message: 'Wrong email or password',
                };
                this.loading = false;
            }
        );
    }
}
