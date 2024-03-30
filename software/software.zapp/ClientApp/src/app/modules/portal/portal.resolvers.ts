import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Resolve,
    RouterStateSnapshot,
} from '@angular/router';
import { forkJoin, Observable, of } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { FuseNavigationItem } from '@fuse/components/navigation';
import { FuseMockApiService } from '@fuse/lib/mock-api';
import { HttpClient } from '@angular/common/http';
import { TranslocoService } from '@ngneat/transloco';
import { AngularFirestore } from '@angular/fire/firestore';
import { InitialDataPortal, portal_san_pham_model } from './portal.types';
import { AuthService } from 'app/core/auth/auth.service';
import { sys_common_number_model } from '../common-model/sys-common-model.types';

@Injectable({
    providedIn: 'root',
})
export class InitialDataPortalResolver implements Resolve<any> {
    private _products: portal_san_pham_model[] = [];
    private _defaultNavigation: FuseNavigationItem[];
    /**
     * Constructor
     */
    constructor(
        private _httpClient: HttpClient,
        private _fuseMockApiService: FuseMockApiService,
        public _translocoService: TranslocoService,
        private db: AngularFirestore,
        private _authService: AuthService
    ) {}

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Use this resolver to resolve initial mock-api for the application
     *
     * @param route
     * @param state
     */

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<InitialDataPortal> {
        // Fork join multiple API endpoint calls to wait all of them to finish
        return forkJoin([
            this._httpClient
                .get<any>('portal_san_pham.ctr/get_list_san_pham')
                .pipe(
                    switchMap((resp: any) => {
                        return of(resp);
                    })
                ),
            this._httpClient.get<any>('sys_loai_san_pham.ctr/getListUse').pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
            this._httpClient.get<any>('sys_lien_ket.ctr/getListUse').pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
            this._httpClient.get<any>('sys_dieu_khoan.ctr/getListUse').pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
            this._httpClient.get<any>('sys_nhan_hieu.ctr/getListUse').pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
            this._httpClient
                .get<any>('sys_thong_tin_website.ctr/getThongTinWebsite')
                .pipe(
                    switchMap((resp: any) => {
                        return of(resp);
                    })
                ),
            this._httpClient.get<any>('sys_banner.ctr/getListUse').pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
            this._httpClient
                .post('/sys_loai_san_pham.ctr/getListUse/', {})
                .pipe(
                    switchMap((resp: any) => {
                        let list_loai_san_pham =
                            resp as sys_common_number_model[];
                        this._defaultNavigation = [];
                        var home: FuseNavigationItem = {
                            link: '/homepage-index',
                            id: 'homepage',
                            module: 'menu',
                            title: 'menu.homepage',
                            translate: 'menu.homepage',
                            type: 'basic',
                        };
                        var gioi_thieu: FuseNavigationItem = {
                            id: 'aboutus',
                            module: 'menu',
                            title: 'menu.gioithieu',
                            translate: 'menu.gioithieu',
                            link: '/portal-gioi-thieu',
                            type: 'basic',
                        };
                        var contact_us: FuseNavigationItem = {
                            id: 'faculty',
                            module: 'menu',
                            title: 'menu.contactus',
                            translate: 'menu.contactus',
                            type: 'basic',
                            link: 'portal-contact-us',
                        };

                        var san_pham: FuseNavigationItem = {
                            id: 'faculty',
                            module: 'menu',
                            title: 'menu.san_pham',
                            translate: 'menu.san_pham',
                            type: 'collapsable',
                            link: 'menu-loai-san-pham',
                            children: [],
                        };
                        for (
                            let index = 0;
                            index < list_loai_san_pham.length;
                            index++
                        ) {
                            const element = list_loai_san_pham[index];
                            var item: FuseNavigationItem = {
                                id: 'faculty',
                                module: 'menu',
                                title: element.name,
                                translate: element.name,
                                type: 'basic',
                                link: 'portal-san-pham/' + element.name,
                            };
                            san_pham.children.push(item);
                        }
                        this._defaultNavigation.push(home);
                        this._defaultNavigation.push(san_pham);
                        this._defaultNavigation.push(gioi_thieu);
                        this._defaultNavigation.push(contact_us);
                        let data = {
                            compact: this._defaultNavigation,
                            default: this._defaultNavigation,
                            futuristic: this._defaultNavigation,
                            horizontal: this._defaultNavigation,
                        };
                        return of(data);
                    })
                ),
            this._httpClient.post('/sys_user.ctr/getUserLogin/', {}).pipe(
                switchMap((resp: any) => {
                    return of(resp);
                })
            ),
        ]).pipe(
            map(
                ([
                    products,
                    type_products,
                    list_lien_ket,
                    list_dieu_khoan,
                    list_nhan_hieu,
                    thong_tin_website,
                    banners,
                    navigation,
                    user,
                ]) => ({
                    products,
                    type_products,
                    list_lien_ket,
                    list_dieu_khoan,
                    list_nhan_hieu,
                    thong_tin_website,
                    banners,
                    navigation: {
                        compact: navigation.compact,
                        default: navigation.default,
                        futuristic: navigation.futuristic,
                        horizontal: navigation.horizontal,
                    },
                    user,
                })
            )
        );
    }
}
