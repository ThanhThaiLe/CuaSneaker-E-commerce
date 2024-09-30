import { HttpClient, HttpEventType } from '@angular/common/http';
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
import { sys_nhan_hieu_model } from './sys-nhan-hieu.types';

@Component({
    selector: 'sys_nhan_hieu_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_nhan_hieu_popupAddComponent extends BasePopUpAddTypeComponent<sys_nhan_hieu_model> {
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_nhan_hieu_popupAddComponent>,
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
            'sys_nhan_hieu',
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
    public image: any;
    public fileUploadProgressWeb: number = -1;
    ChoseFileImageWeb(fileInputWeb: any) {
        this.image = fileInputWeb.target.files;
        this.submitFileWeb();
        fileInputWeb.target.value = null;
    }
    DragAndDropProgressWeb(fileInputWeb: any) {
        this.image = fileInputWeb;
        this.submitFileWeb();
    }
    submitFileWeb() {
        this.fileUploadProgressWeb = 0;
        var formData = new FormData();
        for (var i = 0; i < this.image.length; i++) {
            if (this.image[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.image[i]);
        }
        formData.append('controller', this.controller.toString());
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressWeb = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image = item.location.file_path;
                    this.image = [];
                    this.fileUploadProgressWeb = -1;
                }
            });
    }
}
