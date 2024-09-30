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
import * as AOS from 'aos';
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
import { SeoService } from '@fuse/services/seo.service';
import { InitialDataPortal } from '../portal.types';
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
    selector: 'app-portal-gioi-thieu',
    templateUrl: './portal-gioi-thieu.component.html',
    styleUrls: ['./portal-gioi-thieu.component.scss'],
})
export class PortalGioiThieuComponent implements OnInit {
    public pageLoading: Boolean = false;
    public listBanner: any = [];
    public listBannerHome: any = [];
    public listBannerProduct: any = [];
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
    data: InitialDataPortal;
    constructor(
        public http: HttpClient,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shopping_cardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        public seoService: SeoService,
        private _activatedRoute: ActivatedRoute,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}

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
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.gioi_thieu');
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
        this._activatedRoute.data.subscribe((data: Data) => {
            this.data = data.initialDataPortal;
        });
        this.listBannerHome = this.data.banners.filter((q) => q.id_type == '1');
        this.listBannerProduct = this.data.banners.filter(
            (q) => q.id_type == '2'
        );
        this.pageLoading = false;
    }
}
