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
import { ActivatedRoute, Data, Router } from '@angular/router';
import {
    InitialDataPortal,
    portal_san_pham_chi_tiet_model,
    portal_san_pham_model,
} from '../portal.types';
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
    selector: 'portal_san_pham',
    templateUrl: './portal_san_pham.component.html',
    styleUrls: ['./portal_san_pham.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class PortalSanPhamPageComponent implements OnInit {
    /**
     *  variable
     */
    data: InitialDataPortal;
    public pageLoading: Boolean = false;
    public loai_san_pham: string = '';
    public is_noi_bac: boolean = false;
    public is_khuyen_mai: boolean = false;
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_san_pham: portal_san_pham_model[];
    public list_san_pham_backup: portal_san_pham_model[];
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
    public page_list: number[] = [];
    public total_page = 0;
    public page = 0;
    /**
     * Constructor
     */
    constructor(
        public _http: HttpClient,
        public seoService: SeoService,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        public _translocoService: TranslocoService,
        public _route: ActivatedRoute,
        public _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}
    generate_page() {
        debugger;
        this.page_list = [];
        this.total_page -= 1;
        for (var i = 1; i < this.total_page; i++) {
            this.page_list.push(i);
        }
        console.log(this.page_list);
        console.log(this.total_page);
        console.log(this.page);
    }
    load_san_pham_moi_nhat(page) {
        debugger;
        if (this.total_page == 0) return;
        if (page >= this.total_page) page = this.total_page;
        if (page < 0) page = 0;
        this.page = page;
        this.get_list_san_pham_page();
    }
    go_to_san_pham(product: portal_san_pham_chi_tiet_model) {
        var url = '/portal-product-detail/' + product.ten_san_pham;
        this._router.navigateByUrl(url);
    }
    get_list_san_pham_page() {
        this._http
            .post('portal_san_pham.ctr/get_list_san_pham_page', {
                page: this.page,
            })
            .subscribe((resp) => {
                var data = resp as any;
                this.list_san_pham =
                    data.list_san_pham as portal_san_pham_model[];
                this.list_san_pham_backup =
                    data.list_san_pham as portal_san_pham_model[];
                this.total_page = data.total_page;
                this.generate_page();
            });
    }
    ngOnInit(): void {
        this.pageLoading = true;
        this.get_list_san_pham_page();
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
        this.list_loai_san_pham = this.data.type_products;
        this._route.params.subscribe((params) => {
            this.loai_san_pham = params.name;
        });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.san_pham');
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
        this.pageLoading = false;
    }

    /**
     * Filter by search query
     *
     * @param query
     */
    filterByQuery(query: string): void {
        if (query != '') {
            this.list_san_pham = this.list_san_pham_backup.filter(
                (course) =>
                    course.loai_san_pham
                        .toLowerCase()
                        .includes(query.toLowerCase()) ||
                    course.ma_san_pham
                        .toLowerCase()
                        .includes(query.toLowerCase())
            );
        } else {
            this.list_san_pham = this.list_san_pham_backup;
        }
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Filter by category
     *
     * @param change
     */
    filterByCategory(change: MatSelectChange): void {
        var data = change.value;
        if (data === 'all') {
            this.list_san_pham = this.list_san_pham_backup;
        } else {
            this.list_san_pham = this.list_san_pham_backup.filter(
                (q) => q.id_loai_san_pham == data
            );
        }
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Show/hide completed courses
     *
     * @param change
     */
    toggleCompleted(change: MatSlideToggleChange): void {
        var data = change;
        this.is_noi_bac = data.checked;
        this.list_san_pham = this.list_san_pham_backup.filter(
            (q) =>
                q.is_khuyen_mai == this.is_khuyen_mai &&
                q.is_noi_bac == this.is_noi_bac
        );
        this._changeDetectorRef.markForCheck();
    }

    /**
     * Show/hide completed courses
     *
     * @param change
     */
    toggleCompletedGiamGia(change: MatSlideToggleChange): void {
        var data = change;
        this.is_khuyen_mai = data.checked;
        this.list_san_pham = this.list_san_pham_backup.filter(
            (q) =>
                q.is_khuyen_mai == this.is_khuyen_mai &&
                q.is_noi_bac == this.is_noi_bac
        );
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
