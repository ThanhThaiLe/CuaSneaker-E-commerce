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
import { sys_san_pham_chi_tiet_model } from './sys-san-pham-chi-tiet.types';
import Swal from 'sweetalert2';
import {
    sys_common_number_model,
    sys_common_string_model,
} from 'app/modules/common-model/sys-common-model.types';
import { cm_file_upload_popupComponent } from '@fuse/components/commonComponent/cm_file_upload/cm_file_upload_popup.component';
import { sys_file_upload_db } from 'app/modules/portal/portal.types';

@Component({
    selector: 'sys_san_pham_chi_tiet_popupAdd',
    templateUrl: './popupAdd.component.html',
    styleUrls: ['./popupAdd.component.scss'],
})
export class sys_san_pham_chi_tiet_popupAddComponent extends BasePopUpAddTypeComponent<sys_san_pham_chi_tiet_model> {
    public list_size: sys_common_number_model[] = [];
    public list_color: sys_common_number_model[] = [];
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_nhan_hieu: sys_common_number_model[] = [];
    public list_san_pham: sys_common_string_model[] = [];
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
        public dialogRef: MatDialogRef<sys_san_pham_chi_tiet_popupAddComponent>,
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
            dialogModal
        );

        this.record = data;
        console.log(this.record.list_file);
        this.actionEnum = data.actionEnum;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        if (this.actionEnum == 2 || this.actionEnum == 1) {
            this.get_list_size();
            this.get_list_color();
            this.get_list_san_pham();
            if (this.actionEnum == 1) {
                this.baseInitData();
            }
        }
    }
    public fileDataWeb: any;
    public fileUploadProgressWeb: number = -1;
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
        formData.append('id_parent', this.record.db.id.toString());
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
                    this.record.list_file.push(item.location);
                    this.fileDataWeb = [];
                    this.fileUploadProgressWeb = -1;
                }
            });
    }
    get_list_san_pham() {
        this.http.post('sys_san_pham.ctr/getListUse', {}).subscribe((data) => {
            this.list_san_pham = data as sys_common_string_model[];
        });
    }
    get_list_size() {
        this.http.post('sys_size.ctr/getListUse', {}).subscribe((data) => {
            this.list_size = data as sys_common_number_model[];
        });
    }
    get_list_color() {
        this.http.post('sys_color.ctr/getListUse', {}).subscribe((data) => {
            this.list_color = data as sys_common_number_model[];
        });
    }
}
