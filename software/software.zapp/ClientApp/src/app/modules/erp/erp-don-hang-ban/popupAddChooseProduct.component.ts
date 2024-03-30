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
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { BasePopupDatatabbleComponent } from 'app/Basecomponent/BasePopupDatatabble.component';
import { sys_san_pham_popupAddComponent } from 'app/modules/system/sys-san-pham/popupAdd.component';
import { sys_san_pham_model } from 'app/modules/system/sys-san-pham/sys-san-pham.types';
import { erp_don_hang_ban_chi_tiet_model } from './erp-don-hang-ban-chi-tiet.types';
import { sys_san_pham_chi_tiet_model } from 'app/modules/system/sys-san-pham-chi-tiet/sys-san-pham-chi-tiet.types';
import { forEach } from 'lodash';
import { isThisSecond } from 'date-fns';

@Component({
    selector: 'erp_don_hang_ban_popupAddChooseProduct',
    templateUrl: './popupAddChooseProduct.component.html',
    styleUrls: ['./popupAddChooseProduct.component.scss'],
})
export class erp_don_hang_ban_popupAddChooseProductComponent extends BasePopupDatatabbleComponent {
    public list_size: sys_common_number_model[] = [];
    public list_color: sys_common_number_model[] = [];
    public list_vat: sys_common_number_model[] = [];
    public list_item: erp_don_hang_ban_chi_tiet_model[] = [];
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<erp_don_hang_ban_popupAddChooseProductComponent>,
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
            'sys_san_pham',
            dialogRef,
            dialogModal,
            {
                search: '',
                status_del: 1,
                id_nhan_hieu: -1,
                id_loai_san_pham: -1,
            }
        );
        this.list_item = [];
        this.list_item = data;
    }

    load_list_vat() {
        this.http.post('sys_vat.ctr/getListUse', {}).subscribe((resp) => {
            this.list_vat = resp as sys_common_number_model[];
        });
    }
    chooseItem() {
        this.listData.forEach((element) => {
            element.list_detail.forEach((item) => {
                if (item.is_choose == true) {
                    if (item.id_size == null || item.id_size == undefined) {
                        this.showMessagewarning(
                            'Sản phẩm ' +
                                element.db.ten_san_pham +
                                ' với màu ' +
                                item.color +
                                ' chưa được chọn size'
                        );
                    }
                    const vat = this.list_vat.find((v) => v.value === 0);
                    const size = item.list_size.find(
                        (q) => q.id == item.id_size
                    );
                    let data = {
                        db: {
                            id_san_pham: item.db.id_san_pham,
                            so_luong: 1,
                            don_gia: item.db.gia_ban,
                            id_color: item.db.id_color,
                            id_size: item.id_size,
                            gia_tri_chiet_khau: 0,
                            id_vat: vat.id,
                            gia_tri_vat: vat.value,
                        },
                        ma_san_pham: element.db.ma_san_pham,
                        ten_san_pham: element.db.ten_san_pham,
                        ten_nhan_hieu: element.ten_nhan_hieu,
                        ten_loai_san_pham: element.ten_loai_san_pham,
                        color_code: item.color_code,
                        color: item.color,
                        size: size.name,
                        size_code: size.code,
                        ten_don_vi_tinh: element.ten_don_vi_tinh,
                    } as erp_don_hang_ban_chi_tiet_model;
                    this.list_item.push(data);
                }
            });
        });
        this.basedialogRef.close(this.list_item);
    }
    ngOnInit(): void {
        this.baseInitDataOption('DataHandlerChooseProduct');
        this.load_list_vat();
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialogModal.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
}
