import { Component, Inject, Input } from '@angular/core';
import { TranslocoService } from '@ngneat/transloco';
import Swal from 'sweetalert2';
import { HttpClient, HttpEventType, HttpParams } from '@angular/common/http';
import {
    MatDialog,
    MatDialogRef,
    MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { FuseNavigationService } from '../../../../@fuse/components/navigation/navigation.service';
import { ActivatedRoute } from '@angular/router';
import { BasePopupDatatabbleComponent } from 'app/Basecomponent/BasePopupDatatabble.component';
import { SeoService } from '@fuse/services/seo.service';
import { sys_san_pham_chi_tiet_model } from './sys-san-pham-chi-tiet.types';
@Component({
    selector: 'popupImages',
    templateUrl: './popupImages.component.html',
})
export class popupImagesComponent extends BasePopupDatatabbleComponent {
    public record: any;
    constructor(
        public dialogRef: MatDialogRef<popupImagesComponent>,
        public seoService: SeoService,
        public translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialog: MatDialog,
        public _fuseNavigationService: FuseNavigationService,
        @Inject('BASE_URL') public BASE_URL: string,
        @Inject(MAT_DIALOG_DATA) data: any
    ) {
        super(
            translocoService,
            _fuseNavigationService,
            route,
            BASE_URL,
            http,
            'sys_file_upload',
            dialogRef,
            dialog,
            {
                search: '',
                status_del: 1,
                id_parent: 0,
                controller: '',
            }
        );
        this.record = data as sys_san_pham_chi_tiet_model;
        this.Oldrecord = JSON.parse(JSON.stringify(data));
        this.actionEnum = data.actionEnum;

        if (this.record.list_file == null && this.record.list_file == undefined)
            this.record.list_file = [];
        this.filter.id_parent = this.record.db.id;
        this.filter.controller = this.record.controller;
    }
    fileData: any;
    previewUrl: any = null;
    fileUploadProgress: any = -1;
    uploadedFilePath: string = null;
    formatSizeUnits(bytes) {
        if (bytes >= 1073741824) {
            bytes = (bytes / 1073741824).toFixed(2) + ' GB';
        } else if (bytes >= 1048576) {
            bytes = (bytes / 1048576).toFixed(2) + ' MB';
        } else if (bytes >= 1024) {
            bytes = (bytes / 1024).toFixed(2) + ' KB';
        } else if (bytes > 1) {
            bytes = bytes + ' bytes';
        } else if (bytes == 1) {
            bytes = bytes + ' byte';
        } else {
            bytes = '0 bytes';
        }
        return bytes;
    }
    fileProgress(fileInput: any) {
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
            var extension = this.fileData[0].type;
            if (this.fileData[0].size > 15728640) {
                alert('File upload không được quá 15 Mb!');
                return;
            }
            formData.append('images', this.fileData[i]);
        }
        var modelsubmit = this.record;
        formData.append('model', JSON.stringify(modelsubmit));
        formData.append('controller', this.record.controller.toString());
        formData.append('id_parent', this.record.db.id.toString());
        this.http
            .post(this.controller + '.ctr/upload_file', formData, {
                reportProgress: true,
                observe: 'events',
            })
            .subscribe((res) => {
                if (res.type == HttpEventType.UploadProgress) {
                    this.fileUploadProgress = Math.round(
                        (res.loaded / res.total) * 100
                    );
                } else if (res.type === HttpEventType.Response) {
                    var item: any;
                    item = res.body;
                    this.record.list_file = item;
                    Swal.fire('Lưu Thành công', '', 'success');
                    this.fileData = [];
                    this.baseInitDataTable();
                    this.fileUploadProgress = -1;
                }
            });
    }
    getFontAwesomeIconFromMIME(mimeType) {
        // List of official MIME Types: http://www.iana.org/assignments/media-types/media-types.xhtml
        var icon_classes = {
            // Media
            'image/jpeg': 'assets/icon_file_type/jpg.png',
            'image/png': 'assets/icon_file_type/png.png',
            // Documents
            'application/pdf': 'assets/icon_file_type/pdf.png',
            'application/msword': 'assets/icon_file_type/doc.png',
            'application/vnd.ms-word': 'assets/icon_file_type/doc.png',
            'application/vnd.oasis.opendocument.text':
                'assets/icon_file_type/doc.png',
            'application/vnd.openxmlformats-officedocument.wordprocessingml':
                'assets/icon_file_type/doc.png',
            'application/vnd.ms-excel': 'assets/icon_file_type/excel.png',
            'application/vnd.openxmlformats-officedocument.spreadsheetml':
                'assets/icon_file_type/excel.png',
            'application/vnd.oasis.opendocument.spreadsheet':
                'assets/icon_file_type/excel.png',
            'application/vnd.ms-powerpoint': 'assets/icon_file_type/ppt.png',
            'application/vnd.openxmlformats-officedocument.presentationml':
                'assets/icon_file_type/ppt.png',
            'application/vnd.oasis.opendocument.presentation':
                'assets/icon_file_type/ppt.png',
            'text/plain': 'assets/icon_file_type/txt.png',
            'text/html': 'assets/icon_file_type/html.png',
            'application/json': 'assets/icon_file_type/json-file.png',
            // Archives
            'application/gzip': 'assets/icon_file_type/zip.png',
            'application/x-zip-compressed': 'assets/icon_file_type/zip.png',
            'application/octet-stream': 'assets/icon_file_type/zip-1.png',
        };

        for (var key in icon_classes) {
            if (icon_classes.hasOwnProperty(key)) {
                if (mimeType.search(key) === 0) {
                    // Found it
                    return icon_classes[key];
                }
            } else {
                return 'assets/icon_file_type/file.png';
            }
        }
    }
    deleteFile(id) {
        Swal.fire({
            title: this._translocoService.translate('areYouSure'),
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: this._translocoService.translate('yes'),
            cancelButtonText: this._translocoService.translate('no'),
        }).then((result) => {
            if (result.value) {
                this.http
                    .get(this.controller + '.ctr/update_status/?id=' + id, {})
                    .subscribe(
                        (resp) => {
                            Swal.fire('Xóa thành công', '', 'success').then(
                                (this.record.list_file =
                                    this.record.list_file.filter(
                                        (file) => file.id != id
                                    ))
                            );
                        },
                        (error) => {
                            if (error.status == 400) {
                                this.errorModel = error.error;
                                this.aftersavefail();
                            }
                            if (error.status == 403) {
                                this.basedialogRef.close();
                                Swal.fire(
                                    this._translocoService.translate(
                                        'no_permission'
                                    ),
                                    '',
                                    'warning'
                                );
                            }
                            this.loading = false;
                        }
                    );
            }
        });
    }
}
