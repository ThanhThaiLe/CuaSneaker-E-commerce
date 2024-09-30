import { HttpClient } from '@angular/common/http';
import {
    ChangeDetectorRef,
    Component,
    OnInit,
    TemplateRef,
    ViewEncapsulation,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { TranslocoService } from '@ngneat/transloco';
import { AppConfig } from 'app/core/config/app.config';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import * as AOS from 'aos';
import { PortalProductDetailService } from './portal_product_detail.service';
import {
    portal_san_pham_chi_tiet_model,
    portal_san_pham_chi_tiet_card_model,
    portal_san_pham_model,
} from '../portal.types';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { FuseAlertType } from '@fuse/components/alert';
import { ToastrService } from 'ngx-toastr';
import { SeoService } from '@fuse/services/seo.service';
@Component({
    selector: 'app-portal_product_detail',
    templateUrl: './portal_product_detail.component.html',
    styleUrls: ['./portal_product_detail.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class PortalProductDetailComponent implements OnInit {
    /**
     *  variable
     */
    public pageLoading: Boolean = false;
    public size: sys_common_number_model;
    public ma_san_pham: string = '';
    public product: portal_san_pham_model;
    public product_detail: portal_san_pham_chi_tiet_model;
    public image1: string = '';
    public image2: string = '';
    public image3: string = '';
    public image4: string = '';
    public showAlert: boolean = false;
    public loadingButton: boolean = false;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public isScreenSmall: any;
    public isScreenMobi: any;
    public activeLang: any;
    public config: AppConfig;
    alert: { type: FuseAlertType; message: string } = {
        type: 'success',
        message: '',
    };
    constructor(
        public _http: HttpClient,
        private toastr: ToastrService,
        public seoService: SeoService,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shoppingCardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        public _route: ActivatedRoute,
        public _router: Router,
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
        this._route.params.subscribe((params) => {
            this.ma_san_pham = params.name;

            this.load_product_detail(this.ma_san_pham);
        });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.chi_tiet_san_pham') +
            this.ma_san_pham;
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
    }
    load_product_detail(ma_san_pham) {
        this._http
            .post('portal_san_pham.ctr/get_detail_san_pham', {
                ma_san_pham: ma_san_pham,
            })
            .subscribe((resp) => {
                this.product = resp as portal_san_pham_model;
                this.change_data_product(this.product.list_color[0].code);
            });
    }
    changeCurrency(money): string {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(money);
    }
    change_size(item: sys_common_number_model) {
        this.size = item;
    }
    change_data_product(color_code: string) {
        this.product_detail = this.product.list_san_pham_detail.find(
            (q) => q.color_code === color_code
        );
        this.size = this.product_detail.list_size[0];
        if (this.product_detail.list_file.length > 0) {
            this.image1 = this.product_detail.list_file[0].db.file_path;
            this.image2 = this.product_detail.list_file[1].db.file_path;
            this.image3 = this.product_detail.list_file[2].db.file_path;
            this.image4 = this.product_detail.list_file[3].db.file_path;
        } else {
            this.image1 = 'assets/images/logo/logo.jpg';
            this.image2 = 'assets/images/logo/logo.jpg';
            this.image3 = 'assets/images/logo/logo.jpg';
            this.image4 = 'assets/images/logo/logo.jpg';
        }
        this.pageLoading = false;
    }
    add_san_pham_to_card() {
        this.loadingButton = true;
        setTimeout(() => {
            this._shoppingCardsService.create(this.change_add_product_card());
            this.toastr.success('Sản phẩm đã thêm vào giỏ hàng!', '', {
                timeOut: 3000,
                easing: 'easeOut',
                positionClass: 'toast-top-right',
            });
            this.loadingButton = false;
            // Mở khóa button sau khi hoàn thành xử lý logic
        }, 500);
    }
    change_add_product_card(): portal_san_pham_chi_tiet_card_model {
        var url = '/portal-product-detail/' + this.product.ma_san_pham;
        let item = {
            id: this.product_detail.id,
            id_san_pham: this.product_detail.id_san_pham,
            id_size: this.size.id,
            id_color: this.product_detail.id_color,
            link: url,
            so_luong: 1,
            hinh_anh: this.product.hinh_anh,
            gia_ban: this.product_detail.gia_ban,
            ma_san_pham: this.product.ma_san_pham,
            ten_san_pham: this.product.ten_san_pham,
            size: this.size.code ?? '',
            size_code: this.size.name,
            color: this.product_detail.color,
            color_code: this.product_detail.color_code,
        };
        return item;
    }
}
