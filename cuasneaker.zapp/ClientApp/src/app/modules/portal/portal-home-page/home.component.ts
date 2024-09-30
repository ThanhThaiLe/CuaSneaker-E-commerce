import { HttpClient } from '@angular/common/http';
import {
    ChangeDetectorRef,
    Component,
    OnInit,
    ViewChild,
    ViewEncapsulation,
} from '@angular/core';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { TranslocoService } from '@ngneat/transloco';
import { AppConfig } from 'app/core/config/app.config';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import SwiperCore, {
    Swiper,
    SwiperOptions,
    A11y,
    Autoplay,
    Controller,
    EffectCoverflow,
    EffectCube,
    EffectFade,
    EffectFlip,
    EffectCreative,
    EffectCards,
    HashNavigation,
    History,
    Keyboard,
    Lazy,
    Mousewheel,
    Navigation,
    Pagination,
    Parallax,
    Scrollbar,
    Thumbs,
    Virtual,
    Zoom,
    FreeMode,
    Grid,
    Manipulation,
} from 'swiper';
import { SwiperComponent } from 'swiper/angular';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { MatSelectChange } from '@angular/material/select';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { InitialDataPortal, portal_san_pham_model } from '../portal.types';
import { SeoService } from '@fuse/services/seo.service';
SwiperCore.use([
    A11y,
    Autoplay,
    Controller,
    EffectCoverflow,
    EffectCube,
    EffectFade,
    EffectFlip,
    EffectCreative,
    EffectCards,
    HashNavigation,
    History,
    Keyboard,
    Lazy,
    Mousewheel,
    Navigation,
    Pagination,
    Parallax,
    Scrollbar,
    Thumbs,
    Virtual,
    Zoom,
    FreeMode,
    Grid,
    Manipulation,
]);
@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class HomePageComponent implements OnInit {
    /**
     *  variable
     */
    public pageLoading: Boolean = false;
    data: InitialDataPortal;
    public listBanner: any = [];
    public listBannerHome: any = [];
    public listBannerProduct: any = [];
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_san_pham: portal_san_pham_model[] = [];
    public list_san_pham_backup: portal_san_pham_model[] = [];
    public list_shopping_card: portal_san_pham_model[] = [];
    public unreadCount: any = 0;
    @ViewChild('swiper', { static: false }) swiper?: SwiperComponent;
    slideNext() {
        this.swiper.swiperRef.slideNext(100);
    }
    slidePrev() {
        this.swiper.swiperRef.slidePrev(100);
    }
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public isScreenSmall: any;
    public isScreenMobi: any;
    public activeLang: any;
    public config: AppConfig;
    /**
     * Constructor
     */
    constructor(
        public http: HttpClient,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shopping_cardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        private _router: Router,
        public seoService: SeoService,
        private _activatedRoute: ActivatedRoute,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}
    changeCurrency(money): string {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(money);
    }
    go_to_product_detail(ma_san_pham: string) {
        var url = '/portal-product-detail/' + ma_san_pham;
        this._router.navigateByUrl(url);
    }
    ngOnInit(): void {
        this.pageLoading = true;
        this._fuseMediaWatcherService.onMediaChange$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(({ matchingAliases }) => {
                this.isScreenMobi = !matchingAliases.includes('md');
                this.isScreenSmall = !matchingAliases.includes('sm');
                console.log('isScreenSmall' + this.isScreenSmall);
                console.log('isScreenMobi' + this.isScreenMobi);
            });
        this._fuseConfigService.config$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config: AppConfig) => {
                this.config = config;
            });
        this._translocoService.langChanges$.subscribe((activeLang) => {
            this.activeLang = activeLang;
        });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.trang_chu');
        var metaTag = [
            {
                property: 'og:url',
                content: 'https://i.ibb.co/FnnkQCL/Logo.jpg',
            },
            {
                property: 'og:title',
                content: title,
            },
            {
                property: 'og:image',
                content: '../assets/images/common/images/img_2807.png',
            },
            {
                property: 'og:description',
                content: '',
            },
        ];
        this.seoService.updateTitle(title);
        this.seoService.updateMetaTags(metaTag);
        // Subscribe to the resolved route data
        this._activatedRoute.data.subscribe((data: Data) => {
            this.data = data.initialDataPortal;
        });
        this.pageLoading = false;
    }
    /**
     * Show/hide completed courses
     *
     * @param change
     */
    toggleCompleted(change: MatSlideToggleChange): void {
        var data = change;
        if (data.checked == true) {
            this.list_san_pham = this.list_san_pham.filter(
                (q) => q.is_noi_bac == data.checked
            );
        } else {
            this.list_san_pham = this.list_san_pham_backup;
        }
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Track by function for ngFor loops
     *
     * @param index
     * @param item
     */
    trackByFn(index: number, item: any): any {
        return item.id || index;
    }
}
