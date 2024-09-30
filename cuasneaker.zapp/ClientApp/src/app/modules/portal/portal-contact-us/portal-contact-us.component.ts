import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { TranslocoService } from '@ngneat/transloco';
import * as AOS from 'aos';
import { AppConfig } from 'app/core/config/app.config';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import SwiperCore, {
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
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { SeoService } from '@fuse/services/seo.service';
import { InitialDataPortal } from '../portal.types';
import { sys_thong_tin_website_db } from 'app/modules/system/sys-thong-tin-website/sys-thong-tin-website.types';
import { ActivatedRoute, Data } from '@angular/router';
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
    selector: 'app-portal-contact-us',
    templateUrl: './portal-contact-us.component.html',
    styleUrls: ['./portal-contact-us.component.scss'],
})
export class PortalContactUsComponent implements OnInit {
    public pageLoading: Boolean = false;
    public listBanner: any = [];
    public listBannerHome: any = [];
    public listBannerProduct: any = [];
    data: InitialDataPortal;
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
    public thong_tin_website: sys_thong_tin_website_db;
    constructor(
        public http: HttpClient,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shopping_cardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        private _activatedRoute: ActivatedRoute,
        public seoService: SeoService,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}
    /**
     * Getter for current year
     */
    get currentYear(): number {
        return new Date().getFullYear();
    }
    ngOnInit(): void {
        this.pageLoading = true;
        AOS.init({ duration: 1000 });
        this._fuseMediaWatcherService.onMediaChange$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(({ matchingAliases }) => {
                this.isScreenMobi = !matchingAliases.includes('md');
                this.isScreenSmall = !matchingAliases.includes('sm');
            });
        this._fuseConfigService.config$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config: AppConfig) => {
                this.config = config;
            });
        this._translocoService.langChanges$.subscribe((activeLang) => {
            this.activeLang = activeLang;
        });
        this._activatedRoute.data.subscribe((data: Data) => {
            this.data = data.initialDataPortal;
        });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.contact_us');
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
        this.thong_tin_website = this.data.thong_tin_website;
        this.realoadCapcha();
        this.pageLoading = false;
    }
    srcCaptcha: any;
    errorModel: any;
    realoadCapcha() {
        var d = new Date();
        var n = d.getTime();
        this.srcCaptcha = '/CaptCha/GetCaptChaImage?' + n;
    }
}
