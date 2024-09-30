import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { TranslocoService } from '@ngneat/transloco';
import { AppConfig } from 'app/core/config/app.config';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import * as AOS from 'aos';
import {
    portal_san_pham_chi_tiet_card_model,
    sys_user_nhan_hang_db,
} from '../portal.types';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { SeoService } from '@fuse/services/seo.service';
@Component({
    selector: 'app-portal-payment',
    templateUrl: './portal-payment.component.html',
    styleUrls: ['./portal-payment.component.scss'],
})
export class PortalPaymentComponent implements OnInit {
    horizontalStepperForm: FormGroup;
    verticalStepperForm: FormGroup;
    public pageLoading: Boolean = false;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public isScreenSmall: any;
    public isScreenMobi: any;
    public activeLang: any;
    public config: AppConfig;
    public price_sum: number = 0;
    public productCount: number = 0;
    public loading: boolean = false;
    public list_product_card: portal_san_pham_chi_tiet_card_model[] = [];
    public list_tinh_thanh: sys_common_number_model[] = [];
    public list_quan_huyen: sys_common_number_model[] = [];
    public userNhanHang: sys_user_nhan_hang_db;
    constructor(
        private _formBuilder: FormBuilder,
        public _http: HttpClient,
        public seoService: SeoService,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shopping_cardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        public _route: ActivatedRoute,
        public _router: Router,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}
    public get_list_tinh_thanh() {
        this._http
            .post('sys_tinh_thanh.ctr/getListUse', {})
            .subscribe((resp) => {
                this.list_tinh_thanh = resp as sys_common_number_model[];
            });
    }
    public getInfoReceiver() {
        this._http
            .post('portal_payment.ctr/getInfoReceiver', {})
            .subscribe((resp) => {
                this.userNhanHang = resp as sys_user_nhan_hang_db;
            });
    }
    public initData() {
        this.setLocalStorage();
        this.get_list_tinh_thanh();
        if (this.userNhanHang != null && this.userNhanHang != undefined) {
            // Horizontal stepper form
            this.horizontalStepperForm = this._formBuilder.group({
                step1: this._formBuilder.group({
                    email: [
                        this.userNhanHang.email ?? '',
                        [Validators.required, Validators.email],
                    ],
                    firstName: [
                        this.userNhanHang.first_name ?? '',
                        Validators.required,
                    ],
                    lastName: [
                        this.userNhanHang.last_name ?? '',
                        Validators.required,
                    ],
                    so_dien_thoai: [
                        this.userNhanHang.phone ?? '',
                        Validators.required,
                    ],
                    about: [''],
                }),
                step2: this._formBuilder.group({
                    tinh_thanh: [
                        this.userNhanHang.id_tinh ?? '',
                        Validators.required,
                    ],
                    quan_huyen: [
                        this.userNhanHang.id_quan ?? '',
                        Validators.required,
                    ],
                    dia_chi: [
                        this.userNhanHang.dia_chi_cu_the ?? '',
                        Validators.required,
                    ],
                }),
            });
            // Vertical stepper form
            this.verticalStepperForm = this._formBuilder.group({
                step1: this._formBuilder.group({
                    email: [
                        this.userNhanHang.email ?? '',
                        [Validators.required, Validators.email],
                    ],
                    firstName: [
                        this.userNhanHang.first_name ?? '',
                        Validators.required,
                    ],
                    lastName: [
                        this.userNhanHang.last_name ?? '',
                        Validators.required,
                    ],
                    so_dien_thoai: [
                        this.userNhanHang.phone ?? '',
                        Validators.required,
                    ],
                    about: [this.userNhanHang.email ?? ''],
                }),
                step2: this._formBuilder.group({
                    tinh_thanh: [
                        this.userNhanHang.id_tinh ?? '',
                        Validators.required,
                    ],
                    quan_huyen: [
                        this.userNhanHang.id_quan ?? '',
                        Validators.required,
                    ],
                    dia_chi: [
                        this.userNhanHang.dia_chi_cu_the ?? '',
                        Validators.required,
                    ],
                }),
            });
        } else {
            // Horizontal stepper form
            this.horizontalStepperForm = this._formBuilder.group({
                step1: this._formBuilder.group({
                    email: ['', [Validators.required, Validators.email]],
                    firstName: ['', Validators.required],
                    lastName: ['', Validators.required],
                    so_dien_thoai: ['', Validators.required],
                    about: [''],
                }),
                step2: this._formBuilder.group({
                    tinh_thanh: ['', Validators.required],
                    quan_huyen: ['', Validators.required],
                    dia_chi: ['', Validators.required],
                }),
            });
            // Vertical stepper form
            this.verticalStepperForm = this._formBuilder.group({
                step1: this._formBuilder.group({
                    email: ['', [Validators.required, Validators.email]],
                    firstName: ['', Validators.required],
                    lastName: ['', Validators.required],
                    so_dien_thoai: ['', Validators.required],
                    about: [''],
                }),
                step2: this._formBuilder.group({
                    tinh_thanh: ['', Validators.required],
                    quan_huyen: ['', Validators.required],
                    dia_chi: ['', Validators.required],
                }),
            });
        }
        this.pageLoading = false;
    }
    public change_data() {
        if (!this.isScreenSmall) {
            // Lấy FormGroup của bước 1
            const step2 = this.horizontalStepperForm.get('step2') as FormGroup;
            const step1 = this.horizontalStepperForm.get('step1') as FormGroup;
            // Lấy giá trị từ trường field1 của bước 1
            this.userNhanHang.first_name = step1.get('first_name').value;
            this.userNhanHang.email = step1.get('email').value;
            this.userNhanHang.last_name = step1.get('last_name').value;
            this.userNhanHang.phone = step1.get('phone').value;
            this.userNhanHang.note = step1.get('about').value;

            this.userNhanHang.id_tinh = step2.get('tinh_thanh').value;
            this.userNhanHang.id_tinh = step2.get('tinh_thanh').value;
            this.userNhanHang.dia_chi_cu_the =
                step2.get('dia_chi_cu_the').value;
        } else {
            // Lấy FormGroup của bước 1
            const step1 = this.verticalStepperForm.get('step1') as FormGroup;
            const step2 = this.verticalStepperForm.get('step2') as FormGroup;
            // Lấy giá trị từ trường field1 của bước 1
            // Lấy giá trị từ trường field1 của bước 1
            this.userNhanHang.first_name = step1.get('first_name').value;
            this.userNhanHang.email = step1.get('email').value;
            this.userNhanHang.last_name = step1.get('last_name').value;
            this.userNhanHang.phone = step1.get('phone').value;
            this.userNhanHang.note = step1.get('about').value;

            this.userNhanHang.id_tinh = step2.get('tinh_thanh').value;
            this.userNhanHang.id_tinh = step2.get('tinh_thanh').value;
            this.userNhanHang.dia_chi_cu_the =
                step2.get('dia_chi_cu_the').value;
        }
    }
    public register_don_hang() {
        this.change_data();
        this._http
            .post('portal_payment.ctr/register_don_hang', {
                userNhanHang: this.userNhanHang,
            })
            .subscribe((data) => {});
    }
    public get_list_quan_huyen() {
        let id_tinh_thanh = '';
        if (!this.isScreenSmall) {
            // Lấy FormGroup của bước 1
            const horizontalStepperForm = this.horizontalStepperForm.get(
                'step2'
            ) as FormGroup;
            // Lấy giá trị từ trường field1 của bước 1
            id_tinh_thanh = horizontalStepperForm.get('tinh_thanh').value;
        } else {
            // Lấy FormGroup của bước 1
            const verticalStepperForm = this.verticalStepperForm.get(
                'step2'
            ) as FormGroup;
            // Lấy giá trị từ trường field1 của bước 1
            id_tinh_thanh = verticalStepperForm.get('tinh_thanh').value;
        }
        this._http
            .post('sys_quan_huyen.ctr/getListUseWithIdTinhThanh', {
                id_tinh_thanh: id_tinh_thanh,
            })
            .subscribe((resp) => {
                this.list_quan_huyen = resp as sys_common_number_model[];
            });
    }
    changeCurrency(money): string {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(money);
    }
    go_to_shopping_card() {
        var url = '/portal-shopping-card';
        this._router.navigateByUrl(url);
    }
    go_to_home() {
        var url = '/homepage-index';
        this._router.navigateByUrl(url);
    }
    setLocalStorage() {
        var list = JSON.parse(localStorage.getItem('list_product_card'));
        if (list != null) {
            for (var i = 0; i < list.length; i++) {
                var data = list[i] as portal_san_pham_chi_tiet_card_model;
                this.list_product_card.push(data);
            }
        }
        this._calculateUnreadCount();
    }
    /**
     * Calculate the unread count
     *
     * @private
     */
    private _calculateUnreadCount(): void {
        let count = 0;
        this.price_sum = 0;
        if (this.list_product_card && this.list_product_card.length) {
            count = this.list_product_card.length;
            this.price_sum = this.list_product_card
                .map((c) => c.gia_ban * c.so_luong)
                .reduce((sum, current) => sum + current);
        }
        this.productCount = count;
        this._changeDetectorRef.markForCheck();
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
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.thanh_toan');
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
        this.initData();
    }
}
