import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Resolve,
    RouterStateSnapshot,
} from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { InitialData } from 'app/app.types';
import { cloneDeep } from 'lodash-es';
import { FuseNavigationItem } from '@fuse/components/navigation';
import { FuseMockApiService } from '@fuse/lib/mock-api';
import { HttpClient } from '@angular/common/http';
import { TranslocoService } from '@ngneat/transloco';
import { of } from 'rxjs';
import { AuthService } from './core/auth/auth.service';
import { AngularFirestore } from '@angular/fire/firestore';
import { UserService } from './core/user/user.service';

@Injectable({
    providedIn: 'root',
})
export class InitialDataResolver implements Resolve<any> {
    public menu: any;
    private _defaultNavigation: FuseNavigationItem[] = [];
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
    ): Observable<InitialData> {
        // Fork join multiple API endpoint calls to wait all of them to finish
        return forkJoin([
            this._httpClient.get<any>('sys_home.ctr/checkLogin'),
            this._httpClient.post('/sys_home.ctr/getModule/', {}).pipe(
                switchMap((resp: any) => {
                    this.menu = resp;
                    this._defaultNavigation = [];
                    var menu_id = [];
                    var item_menu: FuseNavigationItem = {
                        id: 'he_thong',
                        module: 'system',
                        title: 'menu.he_thong',
                        translate: 'menu.he_thong',
                        type: 'aside',
                        icon: 'heroicons_outline:home',
                        icon_img: '../assets/images/logo/logo.jpg',
                        children: [],
                    };
                    var menu_admin = false;
                    var menu_system_admin: FuseNavigationItem = {
                        id: 'menu_he_thong',
                        module: 'system',
                        title: 'menu.he_thong',
                        translate: 'menu.he_thong',
                        type: 'collapsable',
                        icon: 'heroicons_outline:home',
                        icon_img: 'apps',
                        children: [],
                    };
                    var menu_he_thong_child = this.menu.filter((item) =>
                        this.checkInclueFn(item.menu.id, [
                            'sys_group_user',
                            'sys_user',
                            'sys_loai_san_pham',
                            'sys_don_vi_tinh',
                            'sys_nhan_hieu',
                            'sys_banner',
                            'sys_san_pham',
                            'sys_san_pham_chi_tiet',
                            'sys_kho',
                            'sys_tinh_thanh',
                            'sys_quoc_gia',
                            'sys_quan_huyen',
                            'sys_type_mail',
                            'sys_template_mail',
                            'sys_color',
                            'sys_size',
                            'sys_lien_ket',
                            'sys_dieu_khoan',
                            'sys_thong_tin_website',
                            'sys_ngan_hang',
                            'sys_vat',
                        ])
                    );
                    if (menu_he_thong_child.length > 0) {
                        menu_admin = true;
                        item_menu.children.push(menu_system_admin);
                        for (
                            let index = 0;
                            index < menu_he_thong_child.length;
                            index++
                        ) {
                            const element = menu_he_thong_child[index];
                            menu_id.push(element.menu.id);
                            menu_system_admin.children.push({
                                id: element.menu.id,
                                badge: element.menu.badge_approval,
                                module: 'system',
                                title: '',
                                link: element.menu.url,
                                translate: element.menu.translate,
                                icon: element.menu.icon,
                                icon_img: element.menu.icon_img,
                                type: 'basic',
                            });
                        }
                        if (menu_admin == true)
                            this._defaultNavigation.push(item_menu);
                    }

                    var item_menu: FuseNavigationItem = {
                        id: 'erp',
                        module: 'system',
                        title: 'menu.erp',
                        translate: 'menu.erp',
                        type: 'aside',
                        icon: 'heroicons_outline:home',
                        icon_img: '../assets/images/logo/logo.jpg',
                        children: [],
                    };
                    var menu_quan_ly_kho = false;
                    var menu_system_quan_ly_kho: FuseNavigationItem = {
                        id: 'menu_quan_ly_kho',
                        module: 'system',
                        title: 'menu.quan_ly_kho',
                        translate: 'menu.quan_ly_kho',
                        type: 'collapsable',
                        icon: 'apps',
                        icon_img: 'apps',
                        children: [],
                    };
                    var menu_quan_ly_kho_child = this.menu.filter((item) =>
                        this.checkInclueFn(item.menu.id, [
                            'erp_nhap_kho',
                            'erp_xuat_kho',
                            'erp_don_vi_van_chuyen',
                            'erp_loai_nhap_xuat',
                            'erp_don_hang_mua',
                            'erp_don_hang_ban',
                        ])
                    );
                    if (menu_quan_ly_kho_child.length > 0) {
                        menu_quan_ly_kho = true;
                        item_menu.children.push(menu_system_quan_ly_kho);
                        for (
                            let index = 0;
                            index < menu_quan_ly_kho_child.length;
                            index++
                        ) {
                            const element = menu_quan_ly_kho_child[index];
                            menu_id.push(element.menu.id);
                            menu_system_quan_ly_kho.children.push({
                                id: element.menu.id,
                                badge: element.menu.badge_approval,
                                module: 'system',
                                title: '',
                                link: element.menu.url,
                                translate: element.menu.translate,
                                icon: element.menu.icon,
                                icon_img: element.menu.icon_img,
                                type: 'basic',
                            });
                        }
                        if (menu_quan_ly_kho == true)
                            this._defaultNavigation.push(item_menu);
                    }

                    resp = {
                        compact: this._defaultNavigation,
                        default: this._defaultNavigation,
                        futuristic: this._defaultNavigation,
                        horizontal: this._defaultNavigation,
                    };
                    return of(resp);
                })
            ),
            this._httpClient.get<any>('sys_home.ctr/checkLogin'),
            this._httpClient.get<any>('sys_home.ctr/checkLogin'),
            this._httpClient
                .post<any>('sys_home.ctr/checkLogin', {
                    accessToken: this._authService.accessToken,
                })
                .pipe(
                    switchMap((resp: any) => {
                        resp = JSON.parse(localStorage.getItem('user'));
                        return of(resp);
                    })
                ),
        ]).pipe(
            map(([messages, navigation, notifications, shortcuts, user]) => ({
                messages,
                navigation: {
                    compact: navigation.compact,
                    default: navigation.default,
                    futuristic: navigation.futuristic,
                    horizontal: navigation.horizontal,
                },
                notifications,
                shortcuts,
                user,
            }))
        );
    }

    checkInclueFn(listInclude: any, stringValue: any): boolean {
        let isInclude = false;
        stringValue.every((element) => {
            if (listInclude === element) {
                isInclude = true;
                return false;
            } else return true;
        });
        return isInclude;
    }
}
