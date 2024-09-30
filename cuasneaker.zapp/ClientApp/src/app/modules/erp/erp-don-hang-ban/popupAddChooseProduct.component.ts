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
import { BasePopupDatatabbleComponent } from 'app/Basecomponent/BasePopupDatatabble.component';

@Component({
    selector: 'erp_don_hang_ban_popupAddChooseProduct',
    templateUrl: './popupAddChooseProduct.component.html',
    styleUrls: ['./popupAddChooseProduct.component.scss'],
})
export class erp_don_hang_ban_popupAddChooseProductComponent extends BasePopupDatatabbleComponent {
    public list_status_del: sys_common_number_model[] = [];
    public list_size: sys_common_number_model[] = [];
    public list_color: sys_common_number_model[] = [];
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
            'sys_san_pham_chi_tiet',
            dialogRef,
            dialogModal,
            {
                search: '',
                status_del: 1,
                id_size: -1,
                id_color: -1,
            }
        );
    }
    ngOnInit(): void {
        this.baseInitDataTable();
        this.get_list_size();
        this.get_list_color();
        this.list_status_del = [
            {
                id: 1,
                name: this._translocoService.translate('common.use'),
            },
            {
                id: 2,
                name: this._translocoService.translate('common.no_user'),
            },
        ];
    }
    get_list_size() {
        this.http.post('sys_size.ctr/getListUse', {}).subscribe((data) => {
            this.list_size = data as sys_common_number_model[];
            this.list_size.splice(0, 0, this.all);
        });
    }
    get_list_color() {
        this.http.post('sys_color.ctr/getListUse', {}).subscribe((data) => {
            this.list_color = data as sys_common_number_model[];
            this.list_color.splice(0, 0, this.all);
        });
    }
}
