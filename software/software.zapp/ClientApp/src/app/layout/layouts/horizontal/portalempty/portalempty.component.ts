import { ChangeDetectorRef, Component, OnDestroy, OnInit, ViewEncapsulation, HostListener } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { FuseNavigationItem, FuseNavigationService, FuseVerticalNavigationComponent } from '@fuse/components/navigation';
import { InitialData } from 'app/app.types';
import { AuthService } from '../../../../core/auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { TranslocoService, AvailableLangs } from '@ngneat/transloco';

@Component({
    selector: 'portalempty-layout',
    templateUrl: './portalempty.component.html',
    styleUrls: ['./portalempty.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class portalemptyLayoutComponent implements OnInit, OnDestroy {
    private _compactNavigation: FuseNavigationItem[];
    private _defaultNavigation: FuseNavigationItem[];
    private _futuristicNavigation: FuseNavigationItem[];
    private _horizontalNavigation: FuseNavigationItem[];
    isScreenSmall: boolean;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public user: any = {
        type: 0
    };
    public unreadCount: any;
    windowScrolledHeader: boolean;

    windowScrolled: boolean;
    public is_login: any = false;
    public list_group_new: any;
    public list_khoa: any;
    public user_htx: any;
    public activeLang: any;
    public thong_tin_website: any = [];
    public list_dieu_khoan_footer: any;
    public navigation: any = {};
    public is_show_hide: any = true;
    /**
     * Constructor
     */
    constructor(
        private _authService: AuthService,
        private changeDetectorRef: ChangeDetectorRef,
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private http: HttpClient,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseMediaWatcherService: FuseMediaWatcherService,
        private _fuseNavigationService: FuseNavigationService,
        private _translocoService: TranslocoService

    ) {
       
       
    }
    public notifications: any = [];
 
    openPanel(): void {
        const url = '/portal_empty_notification';
        this._router.navigateByUrl(url);
    }

    @HostListener("window:scroll", [])
    onWindowScroll(): void {
        if ((window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop) >= 50) {
            this.windowScrolledHeader = true;
            this.windowScrolled = true;
        }
        else {
            this.windowScrolled = false;
            this.windowScrolledHeader = false;
        }



    }
    scrollToTop(): void {
        (function smoothscroll() {
            var currentScroll = document.documentElement.scrollTop || document.body.scrollTop;
            if (currentScroll > 0) {
                window.requestAnimationFrame(smoothscroll);
                window.scrollTo(0, currentScroll - (currentScroll / 8));
            }
        })();
    }



   
    showHide(): void {
        this.is_show_hide = !this.is_show_hide;
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

 
        this._authService.getUser().subscribe((data: any) => {
            if (data != undefined) this.user = data;
        }
        );
        this._authService.check().subscribe((data: any) => {
            this.is_login = data
            if(this.is_login==true){
                // this.loadUser();
            }else{
               
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
        const navigation = this._fuseNavigationService.getComponent<FuseVerticalNavigationComponent>(name);

        if (navigation) {
            // Toggle the opened status
            navigation.toggle();
        }
    }
}
