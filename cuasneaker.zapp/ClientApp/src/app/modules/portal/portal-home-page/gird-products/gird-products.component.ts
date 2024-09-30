import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Data } from '@angular/router';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { SeoService } from '@fuse/services/seo.service';
import { TranslocoService } from '@ngneat/transloco';
import { AppConfig } from 'app/core/config/app.config';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { InitialDataPortal, portal_san_pham_model } from '../../portal.types';
import { MatSelectChange } from '@angular/material/select';
import * as AOS from 'aos';
@Component({
    selector: 'app-gird-products',
    templateUrl: './gird-products.component.html',
    styleUrls: ['./gird-products.component.scss'],
})
export class GirdProductsComponent implements OnInit {
    data: InitialDataPortal;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public isScreenSmall: any;
    public isScreenMobi: any;
    public activeLang: any;
    public config: AppConfig;
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_san_pham: portal_san_pham_model[] = [];
    public list_san_pham_backup: portal_san_pham_model[] = [];
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

    ngOnInit(): void {
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
        this.list_loai_san_pham = this.data.type_products;
        this.list_san_pham = this.data.products;
        this.list_san_pham_backup = this.data.products;
        AOS.init({ duration: 1000 });
    }
    go_to_product_detail(ma_san_pham: string) {
        var url = '/portal-product-detail/' + ma_san_pham;
        this._router.navigateByUrl(url);
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
    /**
     * Filter by search query
     *
     * @param query
     */
    filterByQuery(query: string): void {
        if (query != '') {
            this.list_san_pham = this.list_san_pham_backup.filter(
                (course) =>
                    course.ten_san_pham
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
}
