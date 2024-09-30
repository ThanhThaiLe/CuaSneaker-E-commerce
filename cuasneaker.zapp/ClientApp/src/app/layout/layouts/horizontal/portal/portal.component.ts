import {
    Component,
    OnDestroy,
    OnInit,
    ViewEncapsulation,
    HostListener,
} from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import {
    FuseNavigationService,
    FuseVerticalNavigationComponent,
} from '@fuse/components/navigation';
import { AuthService } from '../../../../core/auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { TranslocoService } from '@ngneat/transloco';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { InitialDataPortal } from 'app/modules/portal/portal.types';
import { sys_thong_tin_website_db } from 'app/modules/system/sys-thong-tin-website/sys-thong-tin-website.types';
import { User } from 'app/core/user/user.model';
@Component({
    selector: 'portal-layout',
    templateUrl: './portal.component.html',
    styleUrls: ['./portal.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class portalLayoutComponent implements OnInit, OnDestroy {
    isScreenSmall: boolean;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    windowScrolledHeader: boolean;
    windowScrolled: boolean;
    public is_login: any = false;
    public user: User;
    public activeLang: any;
    public thong_tin_website: sys_thong_tin_website_db;
    public list_dieu_khoan: sys_common_number_model[] = [];
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_lien_ket: sys_common_number_model[] = [];
    public navigation: any = {};
    public is_show_hide: any = true;
    data: InitialDataPortal;
    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        private _router: Router,
        private _fuseMediaWatcherService: FuseMediaWatcherService,
        private _fuseNavigationService: FuseNavigationService,
        private _activatedRoute: ActivatedRoute,
        private _translocoService: TranslocoService
    ) {}
    @HostListener('window:scroll', [])
    onWindowScroll(): void {
        if (
            (window.pageYOffset ||
                document.documentElement.scrollTop ||
                document.body.scrollTop) >= 50
        ) {
            this.windowScrolledHeader = true;
            this.windowScrolled = true;
        } else {
            this.windowScrolled = false;
            this.windowScrolledHeader = false;
        }
    }
    scrollToTop(): void {
        (function smoothscroll() {
            var currentScroll =
                document.documentElement.scrollTop || document.body.scrollTop;
            if (currentScroll > 0) {
                window.requestAnimationFrame(smoothscroll);
                window.scrollTo(0, currentScroll - currentScroll / 8);
            }
        })();
    }
    showHide(): void {
        this.is_show_hide = !this.is_show_hide;
    }
    go_to_home() {
        var url = '/home';
        this._router.navigateByUrl(url);
    }
    go_to_homepage() {
        var url = '/homepage-index';
        this._router.navigateByUrl(url);
    }
    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Getter for current year
     */
    get currentYear(): number {
        return new Date().getFullYear();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Lifecycle hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On init
     */
    ngOnInit(): void {
        this._activatedRoute.data.subscribe((data: Data) => {
            this.data = data.initialDataPortal;
        });
        this.list_loai_san_pham = this.data.type_products;
        this.navigation = this.data.navigation;
        this.list_lien_ket = this.data.list_lien_ket;
        this.list_dieu_khoan = this.data.list_dieu_khoan;

        this.thong_tin_website = this.data.thong_tin_website;
        this._authService.check().subscribe((data: any) => {
            this.is_login = data;
            if (this.is_login == true) {
                this.user = this.data.user;
            }
        });
        this._translocoService.langChanges$.subscribe((activeLang) => {
            //en
            this.activeLang = activeLang;
        });

        // Subscribe to media changes
        this._fuseMediaWatcherService.onMediaChange$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(({ matchingAliases }) => {
                // Check if the screen is small
                this.isScreenSmall = !matchingAliases.includes('md');
            });
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Toggle navigation
     *
     * @param name
     */
    toggleNavigation(name: string): void {
        // Get the navigation
        const navigation =
            this._fuseNavigationService.getComponent<FuseVerticalNavigationComponent>(
                name
            );

        if (navigation) {
            // Toggle the opened status
            navigation.toggle();
        }
    }
}
