import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import {
    MAT_DIALOG_DATA,
    MatDialog,
    MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { BasePopUpAddTypeComponent } from 'app/Basecomponent/BasePopupAddType.component';
import { erp_don_hang_ban_model } from './erp-don-hang-ban.types';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { erp_don_hang_ban_chi_tiet_model } from './erp-don-hang-ban-chi-tiet.types';
import { erp_don_hang_ban_popupAddChooseProductComponent } from './popupAddChooseProduct.component';
import { sys_san_pham_popupAddComponent } from 'app/modules/system/sys-san-pham/popupAdd.component';

@Component({
    selector: 'erp_don_hang_ban_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class erp_don_hang_ban_popupAddComponent extends BasePopUpAddTypeComponent<erp_don_hang_ban_model> {
    public list_loai_don_hang: sys_common_number_model[] = [];
    public list_phuong_thuc_thanh_toan: sys_common_number_model[] = [];
    public list_loai_chuyen_khoan: sys_common_number_model[] = [];
    public list_vat: sys_common_number_model[] = [];
    public list_ngan_hang: sys_common_number_model[] = [];
    public list_tinh_thanh: sys_common_number_model[] = [];
    public list_quan_huyen: sys_common_number_model[] = [];
    public list_quan_huyen_nhan: sys_common_number_model[] = [];
    public list_quan_huyen_dat: sys_common_number_model[] = [];
    public list_don_vi_van_chuyen: sys_common_number_model[] = [];
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<erp_don_hang_ban_popupAddComponent>,
        public dialogModal: MatDialog,
        public _fuseNavigationService: FuseNavigationService,
        @Inject(MAT_DIALOG_DATA) data: any,
        @Inject('BASE_URL') public _baseUrl: string
    ) {
        super(
            _translocoService,
            _fuseNavigationService,
            route,
            _baseUrl,
            http,
            'erp_don_hang_ban',
            dialogRef,
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
    }
    ngOnInit(): void {
        this.load_list_loai_don_hang();
        this.load_list_phuong_thuc_thanh_toan();
        this.load_list_loai_chuyen_khoan();
        this.load_list_don_vi_van_chuyen();
        this.load_list_vat();
        this.load_list_ngan_hang();
        this.get_list_tinh_thanh();
        this.get_list_quan_huyen();
        if (this.actionEnum == 1) {
            this.record.db.code = 'Tự động tạo';
            this.record.db.name = 'Tự động tạo';
            this.record.list_detail = [];
            this.record.db.ngay_dat_hang = new Date();
            this.record.db.ngay_du_kien_giao = new Date();
            this.record.db.loai_don_hang = 1;
            this.record.db.phuong_thuc_thanh_toan = 1;
            this.record.db.so_ngay_du_kien_giao = 0;
            let vat = this.list_vat.find((v) => v.value === 0);
            this.record.db.id_ty_le_vat = vat.id;
            this.record.db.ty_le_vat = vat.value;
            this.baseInitData();
        }
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialogModal.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {});
    }

    change_callback_data_money_item_detail(index: number) {
        let item = this.record.list_detail[index];
        this.change_data_money_item_detail(item);
    }
    change_data_order() {
        // Tổng Thành tiền sau chiết khấu (bao gồm phí vận chuyển)
        this.record.db.thanh_tien_chiet_khau =
            this.record.db.thanh_tien_van_chuyen_truoc_thue +
            this.record.db.thanh_tien_chiet_khau;
        // Tổng Tiền thuế (bao gồm thuế vận chuyển)
        this.record.db.tien_thue =
            this.record.db.tien_thue + this.record.db.tien_thue_van_chuyen;
        // Tổng Thành tiền sau thuế (bao gồm phí vận chuyển)
        this.record.db.thanh_tien_sau_thue =
            this.record.db.thanh_tien_sau_thue +
            this.record.db.thanh_tien_van_chuyen_sau_thue;
    }
    change_data_money_item_detail(
        item: erp_don_hang_ban_chi_tiet_model
    ): erp_don_hang_ban_chi_tiet_model {
        // TODO:
        // thanh_tien_truoc_thue = so_luong * don_gia
        item.db.thanh_tien_truoc_thue = item.db.so_luong * item.db.don_gia;
        // thanh_tien_chiet_khau = thanh_tien_truoc_thue * gia_tri_chiet_khau / 100
        // sau đó tính lại thành tiền trước thuế = thành tiền trước thuế - thành tiền chiết khấu
        item.db.thanh_tien_chiet_khau =
            item.db.thanh_tien_truoc_thue * (item.db.gia_tri_chiet_khau / 100);
        item.db.thanh_tien_truoc_thue =
            item.db.thanh_tien_truoc_thue - item.db.thanh_tien_chiet_khau;
        // thanh_tien_thue = thanh_tien_truoc_thue * gia_tri_vat
        item.db.thanh_tien_thue =
            item.db.thanh_tien_truoc_thue * item.db.gia_tri_vat;
        // thanh_tien_sau_thue = thanh_tien_thue + thanh_tien_truoc_thue - thanh_tien_chiet_khau
        item.db.thanh_tien_sau_thue =
            item.db.thanh_tien_thue +
            item.db.thanh_tien_truoc_thue -
            item.db.thanh_tien_chiet_khau;
        return item;
    }
    change_money() {
        this.record.list_detail.forEach((item) => {
            item = this.change_data_money_item_detail(item);
        });
    }
    chooseSanPham() {
        const dialog = this.dialogModal.open(
            erp_don_hang_ban_popupAddChooseProductComponent,
            {
                disableClose: true,
                width: '80%',
                data: this.record.list_detail,
            }
        );
        dialog.afterClosed().subscribe((data) => {
            this.record.list_detail = data as erp_don_hang_ban_chi_tiet_model[];
        });
    }
    change_quan_huyen_nguoi_nhan() {
        this.list_quan_huyen_nhan = this.list_quan_huyen.filter(
            (q) => q.id_tinh == this.record.db.id_tinh_khach_hang_nhan
        );
    }
    change_quan_huyen_nguoi_dat() {
        this.list_quan_huyen_dat = this.list_quan_huyen.filter(
            (q) => q.id_tinh == this.record.db.id_tinh_khach_hang_dat
        );
    }
    change_ngay_du_kien_giao_hang() {
        var date = new Date();
        var day1 = this.record.db.ngay_du_kien_giao.getDate() * 1;
        var day2 = this.record.db.so_ngay_du_kien_giao * 1;
        var total_day = day1 + day2;
        date.setDate(total_day);
        this.record.db.ngay_du_kien_giao = date;
    }
    change_ty_le_vat_van_chuyen() {
        let thanh_tien_van_chuyen_truoc_thue: number =
            (this.record.db.thanh_tien_van_chuyen_truoc_thue as number) * 1;
        this.record.db.ty_le_vat_van_chuyen = this.list_vat.find(
            (vat) => vat.id == this.record.db.id_ty_le_vat_van_chuyen
        ).value;
        this.record.db.tien_thue_van_chuyen =
            thanh_tien_van_chuyen_truoc_thue *
            this.record.db.ty_le_vat_van_chuyen;
        this.record.db.thanh_tien_van_chuyen_sau_thue =
            thanh_tien_van_chuyen_truoc_thue +
            this.record.db.tien_thue_van_chuyen;
    }

    get_list_tinh_thanh() {
        this.http
            .post('sys_tinh_thanh.ctr/getListUse', {})
            .subscribe((resp) => {
                this.list_tinh_thanh = resp as sys_common_number_model[];
            });
    }
    get_list_quan_huyen() {
        this.http
            .post('sys_quan_huyen.ctr/getListUse', {})
            .subscribe((resp) => {
                this.list_quan_huyen = resp as sys_common_number_model[];
            });
    }
    load_list_vat() {
        this.http.post('sys_vat.ctr/getListUse', {}).subscribe((resp) => {
            this.list_vat = resp as sys_common_number_model[];
        });
    }
    load_list_ngan_hang() {
        this.http.post('sys_ngan_hang.ctr/getListUse', {}).subscribe((resp) => {
            this.list_ngan_hang = resp as sys_common_number_model[];
        });
    }
    load_list_don_vi_van_chuyen() {
        this.http
            .post('erp_don_vi_van_chuyen.ctr/getListUse', {})
            .subscribe((resp) => {
                this.list_don_vi_van_chuyen = resp as sys_common_number_model[];
            });
    }
    load_list_loai_don_hang() {
        this.list_loai_don_hang = [
            {
                id: 1,
                name: 'Hàng hóa',
            },
            {
                id: 2,
                name: 'Dịch vụ',
            },
        ];
    }
    load_list_phuong_thuc_thanh_toan() {
        this.list_phuong_thuc_thanh_toan = [
            {
                id: 1,
                name: 'Tiền mặt',
            },
            {
                id: 2,
                name: 'Chuyển khoản',
            },
        ];
    }
    load_list_loai_chuyen_khoan() {
        this.list_loai_chuyen_khoan = [
            {
                id: 1,
                name: 'Momo',
            },
            {
                id: 2,
                name: 'VNPay',
            },
            {
                id: 3,
                name: 'Tài khoản ngân hàng',
            },
        ];
    }
}
