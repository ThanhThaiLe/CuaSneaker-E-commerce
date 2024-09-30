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
import { sys_san_pham_model } from './sys-san-pham.types';
import Swal from 'sweetalert2';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { cm_file_upload_popupComponent } from '@fuse/components/commonComponent/cm_file_upload/cm_file_upload_popup.component';
import { sys_san_pham_chi_tiet_model } from '../sys-san-pham-chi-tiet/sys-san-pham-chi-tiet.types';

@Component({
    selector: 'sys_san_pham_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_san_pham_popupAddComponent extends BasePopUpAddTypeComponent<sys_san_pham_model> {
    public list_size: sys_common_number_model[] = [];
    public list_color: sys_common_number_model[] = [];
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_nhan_hieu: sys_common_number_model[] = [];
    public list_don_vi_tinh: sys_common_number_model[] = [];
    fileData: any;
    fileUploadProgress: number = -1;
    public plugintiny = [
        'advlist autolink lists link image charmap print preview anchor',
        'searchreplace visualblocks code fullscreen',
        'insertdatetime media table paste imagetools wordcount',
    ];
    public toolbartiny =
        'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignjustify | bullist numlist outdent indent | link image';
    public timyconfig = {
        base_url: '/tinymce',
        suffix: '.min',
        height: 500,
        images_upload_url: 'FileManager/uploadimage',
        plugins: this.plugintiny,
        toolbar: this.toolbartiny,
    };
    constructor(
        public _translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialogRef: MatDialogRef<sys_san_pham_popupAddComponent>,
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
            dialogModal
        );
        this.record = data;
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        if (this.actionEnum != 3) {
            this.get_list_don_vi_tinh();
            this.get_list_nhan_hieu();
            this.get_list_loai_san_pham();
            if (this.actionEnum == 1) {
                this.get_code_san_pham();
                this.baseInitData();
                this.record.list_detail = [];
            }
        } else {
            this.getElementById();
        }
    }
    getElementById() {
        this.http
            .get(
                this.controller + '.ctr/getElementById?id=' + this.record.db.id,
                {}
            )
            .subscribe((data) => {
                this.record = data as sys_san_pham_model;
            });
    }

    openDialogFileUpload(model: any, pos: any) {
        const dialog = this.dialogModal.open(cm_file_upload_popupComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data.db.id == 0) return;
        });
    }
    get_code_san_pham() {
        this.http
            .post(this.controller + '.ctr/get_code_san_pham', {})
            .subscribe((data) => {
                this.record.db.ma_san_pham = data as string;
            });
    }
    get_list_loai_san_pham() {
        this.http
            .post('sys_loai_san_pham.ctr/getListUse', {})
            .subscribe((data) => {
                this.list_loai_san_pham = data as sys_common_number_model[];
            });
    }
    get_list_nhan_hieu() {
        this.http.post('sys_nhan_hieu.ctr/getListUse', {}).subscribe((data) => {
            this.list_nhan_hieu = data as sys_common_number_model[];
        });
    }
    get_list_don_vi_tinh() {
        this.http
            .post('sys_don_vi_tinh.ctr/getListUse', {})
            .subscribe((data) => {
                this.list_don_vi_tinh = data as sys_common_number_model[];
            });
    }
    ChoseFileImage(fileInput: any) {
        this.fileData = fileInput.target.files;
        this.submitFile();
        fileInput.target.value = null;
    }
    DragAndDropProgress(files: any) {
        this.fileData = files;
        this.submitFile();
    }
    submitFile() {
        this.fileUploadProgress = 0;
        var formData = new FormData();
        for (var i = 0; i < this.fileData.length; i++) {
            if (this.fileData[0].size > 15728640) {
                this.showMessagewarning(
                    'File upload không được quá 15 Mb!',
                    ''
                );
                return;
            }
            formData.append('list_file[]', this.fileData[i]);
        }
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        this.http
            .post('/FileManager/uploadimage', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgress = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    // this.showMessageSuccess();
                    var item: any;
                    item = res.body;
                    this.record.db.hinh_anh = item.location.file_path;
                    this.fileData = [];
                    this.fileUploadProgress = -1;
                }
            });
    }
}
