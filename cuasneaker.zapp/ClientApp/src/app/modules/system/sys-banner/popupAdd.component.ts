import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import {
    MAT_DIALOG_DATA,
    MatDialog,
    MatDialogRef,
} from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { BasePopUpAddComponent } from 'app/Basecomponent/BasePopupAdd.component';
import { BasePopUpAddTypeComponent } from 'app/Basecomponent/BasePopupAddType.component';
import { sys_banner_model } from './sys-banner.types';

@Component({
    selector: 'sys_banner_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_banner_popupAddComponent extends BasePopUpAddTypeComponent<sys_banner_model> {
    public list_type_banner: any = [];
    public fileDataWeb: any;
    public fileUploadProgressWeb: number = -1;
    public fileDataMobi: any;
    public fileUploadProgressMobi: number = -1;
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_banner_popupAddComponent>,
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
            'sys_banner',
            dialogRef,
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        this.list_type_banner = [
            {
                id: 1,
                name: this._translocoService.translate('system.trang_chu'),
            },
            {
                id: 2,
                name: this._translocoService.translate('system.san_pham'),
            },
        ];
        if (this.actionEnum == 1) {
            this.baseInitData();
        }
    }
    ChoseFileImageWeb(fileInputWeb: any) {
        this.fileDataWeb = fileInputWeb.target.files;
        this.submitFileWeb();
        fileInputWeb.target.value = null;
    }
    DragAndDropProgressWeb(fileInputWeb: any) {
        this.fileDataWeb = fileInputWeb;
        this.submitFileWeb();
    }
    submitFileWeb() {
        this.fileUploadProgressWeb = 0;
        var formData = new FormData();
        for (var i = 0; i < this.fileDataWeb.length; i++) {
            if (this.fileDataWeb[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.fileDataWeb[i]);
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
                    this.record.db.image_web = item.location.file_path;
                    this.fileDataWeb = [];
                    this.fileUploadProgressWeb = -1;
                }
            });
    }
    ChoseFileImageMobi(fileInputMobi: any) {
        this.fileDataMobi = fileInputMobi.target.files;
        this.submitFileMobi();
        fileInputMobi.target.value = null;
    }
    DragAndDropProgressMobi(fileInputMobi: any) {
        this.fileDataMobi = fileInputMobi;
        this.submitFileMobi();
    }
    submitFileMobi() {
        this.fileUploadProgressMobi = 0;
        var formData = new FormData();
        for (var i = 0; i < this.fileDataMobi.length; i++) {
            if (this.fileDataMobi[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.fileDataMobi[i]);
        }
        var modelsubmit = this.record;
        formData.append('controller', this.controller.toString());
        // formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgressMobi = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.image_mobi = item.location.file_path;
                    this.fileDataMobi = [];
                    this.fileUploadProgressMobi = -1;
                }
            });
    }
}
