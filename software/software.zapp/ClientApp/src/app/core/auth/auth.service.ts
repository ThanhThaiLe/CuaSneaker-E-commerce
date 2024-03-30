import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { from, Observable, of, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { AuthUtils } from 'app/core/auth/auth.utils';
import { UserService } from 'app/core/user/user.service';
import { token_noti_user } from '../models/firebase_model';
import moment from 'moment';
import {
    AngularFirestore,
    AngularFirestoreCollection,
    DocumentReference,
} from '@angular/fire/firestore';
import { User } from '../user/user.model';
import * as CryptoJS from 'crypto-js';
import { DatePipe } from '@angular/common';
@Injectable()
export class AuthService {
    private _authenticated: boolean = false;
    token_noti_users$: Observable<token_noti_user[]>;
    tokenFromUI: string = '432646294A404E63';
    user: User;
    /**
     * Constructor
     */
    constructor(
        public datepipe: DatePipe,
        private _httpClient: HttpClient,
        private _userService: UserService
    ) {}

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Setter & getter for access token
     */

    encryptUsingAES256(text) {
        let _key = CryptoJS.enc.Utf8.parse(this.tokenFromUI);
        let _iv = CryptoJS.enc.Utf8.parse(this.tokenFromUI);
        let encrypted = CryptoJS.AES.encrypt(text, _key, {
            keySize: 16,
            iv: _iv,
            mode: CryptoJS.mode.ECB,
            padding: CryptoJS.pad.Pkcs7,
        });
        return encrypted.toString();
    }
    decryptUsingAES256(text) {
        let _key = CryptoJS.enc.Utf8.parse(this.tokenFromUI);
        let _iv = CryptoJS.enc.Utf8.parse(this.tokenFromUI);

        return CryptoJS.AES.decrypt(text, _key, {
            keySize: 16,
            iv: _iv,
            mode: CryptoJS.mode.ECB,
            padding: CryptoJS.pad.Pkcs7,
        }).toString(CryptoJS.enc.Utf8);
    }
    set accessToken(token: string) {
        localStorage.setItem(
            this.encryptUsingAES256('CuaSneaker_thanh_thai_le'),
            this.encryptUsingAES256(token)
        );
    }

    get accessToken(): string {
        var token = localStorage.getItem(
            this.encryptUsingAES256('CuaSneaker_thanh_thai_le')
        );
        if (token == null || token == undefined || token == '') return '';
        else {
            return this.decryptUsingAES256(token);
        }
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Forgot password
     *
     * @param phone
     */
    forgotPassword(email: string, captcha: string): Observable<any> {
        return this._httpClient.post('/sys_user.ctr/forgot_pass', {
            email: email,
            captcha: captcha,
        });
    }

    /**
     * Reset password
     *
     * @param password
     */
    resetPassword(
        password: string,
        repassword: string,
        iduser: string
    ): Observable<any> {
        return this._httpClient.post('/sys_user.ctr/changePasswordNonLogin', {
            password: password,
            repassword: repassword,
            iduser: iduser,
        });
    }

    /**
     * Sign in
     *
     * @param credentials
     */
    signIn(credentials: {
        username: string;
        password: string;
        showCapcha: number;
    }): Observable<any> {
        // Throw error, if the user is already logged in
        if (this._authenticated) {
            return throwError('User is already logged in.');
        }

        return this._httpClient
            .post('sys_user.ctr/authenticate', { data: credentials })
            .pipe(
                switchMap((response: any) => {
                    // Store the access token in the local storage
                    this.accessToken = response.token;

                    // Set the authenticated flag to true
                    this._authenticated = true;

                    // Store the user on the user service
                    this._userService.user = {
                        id: response.id,
                        name: response.user_name,
                        type: response.type,
                        email: response.email,
                        // avatar: response.avatar_path,
                        status: 'online',
                    };
                    this._userService.user$.subscribe((user) => {
                        localStorage.setItem('user', JSON.stringify(user));
                    });

                    // Return a new observable with the response
                    return of(response);
                })
            );
    }
    signInNew(record): Observable<any> {
        // Throw error, if the user is already logged in
        if (this._authenticated) {
            return throwError('User is already logged in.');
        }

        return this._httpClient
            .post('sys_user.ctr/authenticate', {
                data: record,
            })
            .pipe(
                switchMap((response: any) => {
                    // Store the access token in the local storage
                    this.accessToken = response.token;

                    // Set the authenticated flag to true
                    this._authenticated = true;

                    // Store the user on the user service
                    this._userService.user = {
                        id: response.id,
                        name: response.full_name,
                        type: response.type,
                        status_del: response.status_del,
                        email: response.email,
                        avatar: response.avatar_path,
                        status: 'online',
                    };
                    this._userService.user$.subscribe((user) => {
                        localStorage.setItem('user', JSON.stringify(user));
                    });

                    // Return a new observable with the response
                    return of(response);
                })
            );
    }
    getUser(): Observable<any> {
        var resp = JSON.parse(localStorage.getItem('user'));
        return of(resp);
    }
    /**
     * Sign in using the access token
     */
    signInUsingToken(): Observable<any> {
        // Renew token
        return this._httpClient
            .post('sys_home.ctr/checkLogin', {
                accessToken: this.accessToken,
            })
            .pipe(
                catchError(() =>
                    // Return false
                    of(false)
                ),
                switchMap((response: any) => {
                    // Store the access token in the local storage
                    // this.accessToken = response.accessToken;

                    // Set the authenticated flag to true
                    this._authenticated = true;

                    // Store the user on the user service
                    this._userService.user = JSON.parse(
                        localStorage.getItem('user')
                    );

                    // Return true
                    return of(true);
                })
            );
    }

    /**
     * Sign out
     */
    signOut(): Observable<any> {
        // Remove the access token from the local storage

        localStorage.removeItem('menu_user');
        localStorage.removeItem('user');
        localStorage.removeItem(
            this.encryptUsingAES256('CuaSneaker_thanh_thai_le')
        );
        // Set the authenticated flag to false
        this._authenticated = false;

        // Return the observable
        return of(true);
    }

    /**
     * Sign up
     *
     * @param user
     */
    signUp(user: any): Observable<any> {
        return this._httpClient.post('sys_user.ctr/register', { user: user });
    }

    /**
     * Unlock session
     *
     * @param credentials
     */
    unlockSession(credentials: {
        email: string;
        password: string;
    }): Observable<any> {
        return this._httpClient.post('api/auth/unlock-session', credentials);
    }

    /**
     * Check the authentication status
     */
    check(): Observable<boolean> {
        // Check if the user is logged in
        if (this._authenticated) {
            return of(true);
        }

        // Check the access token availability
        if (!this.accessToken) {
            return of(false);
        }

        // Check the access token expire date
        if (AuthUtils.isTokenExpired(this.accessToken)) {
            return of(false);
        }

        // If the access token exists and it didn't expire, sign in using it
        return this.signInUsingToken();
    }
    checklogin(): boolean {
        // Check if the user is logged in
        if (this._authenticated) {
            return true;
        }

        // Check the access token availability
        if (!this.accessToken) {
            return false;
        }

        // Check the access token expire date
        if (AuthUtils.isTokenExpired(this.accessToken)) {
            return false;
        }
    }
}
