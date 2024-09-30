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
import { sys_quan_huyen_model } from './sys-quan-huyen.types';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';

@Component({
    selector: 'sys_quan_huyen_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_quan_huyen_popupAddComponent extends BasePopUpAddTypeComponent<sys_quan_huyen_model> {
    public list_quoc_gia: sys_common_number_model[] = [];
    public list_tinh_thanh: sys_common_number_model[] = [];
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_quan_huyen_popupAddComponent>,
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
            'sys_quan_huyen',
            dialogRef,
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        if (this.actionEnum == 1) {
            this.baseInitData();
        }
    }
    get_list_quoc_gia() {
        this.http.post('sys_quoc_gia.ctr/getListUse', {}).subscribe((data) => {
            this.list_quoc_gia = data as sys_common_number_model[];
        });
    }
    get_list_tinh_thanh() {
        this.http
            .post('sys_tinh_thanh.ctr/getListUse', {
                id_quoc_gia: this.record.db.id_quoc_gia,
            })
            .subscribe((data) => {
                this.list_tinh_thanh = data as sys_common_number_model[];
            });
    }
}
