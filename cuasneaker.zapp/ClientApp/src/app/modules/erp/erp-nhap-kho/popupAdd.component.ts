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
import { erp_nhap_kho_model } from './erp-nhap-kho.types';

@Component({
    selector: 'erp_nhap_kho_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class erp_nhap_kho_popupAddComponent extends BasePopUpAddTypeComponent<erp_nhap_kho_model> {
    public list_loai_nhap: any;
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<erp_nhap_kho_popupAddComponent>,
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
            'erp_nhap_kho',
            dialogRef,
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        if (this.actionEnum == 1) {
            this.baseInitData();
        }
        this.list_loai_nhap = [
            {
                id: 1,
                name: this._translocoService.translate('erp.nhap_mua'),
            },
            {
                id: 2,
                name: this._translocoService.translate('erp.nhap_san_xuat'),
            },
            {
                id: 3,
                name: this._translocoService.translate('erp.nhap_thu_hoi'),
            },
            {
                id: 4,
                name: this._translocoService.translate('erp.nhap_ghi_tang'),
            },
        ];
    }
}
