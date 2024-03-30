import { Directive } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
import { TranslocoService } from '@ngneat/transloco';
import { FuseNavigationService } from '@fuse/components/navigation';
@Directive()
export abstract class BasePopUpAddTypeComponent<T> {
    public Oldrecord: T;
    public record: T;
    public errorModel: any;
    public actionEnum: number;
    public baseurl: String;
    public pageLoading: Boolean = false;
    public loading: boolean = false;
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
    ngOnInit(): void {}
    constructor(
        public _translocoService: TranslocoService,
        public _fuseNavigationService: FuseNavigationService,
        public route: ActivatedRoute,
        _baseUrl: string,
        public http: HttpClient,
        public controller: String,
        public basedialogRef: any,
        public dialogModal: any
    ) {
        this.errorModel = [];
        this.baseurl = _baseUrl;
    }
    addDays(date, days: number = 0) {
        var result = new Date(); // not instatiated with date!!! DANGER
        result.setDate(date.getDate() + days);
        return result;
    }
    public showLoading(title: any, html: any, showClose: boolean) {
        if (title == '')
            title = this._translocoService.translate('common.vui_long_doi');
        if (html == '')
            html = this._translocoService.translate('common.dang_tai_du_lieu');
        Swal.fire({
            title: title,
            html: html,
            allowOutsideClick: false,
            showCloseButton: showClose,
            showCancelButton: false,
            showConfirmButton: false,
            willOpen: () => {
                Swal.showLoading();
            },
        });
    }

    public showMessageinfo(title: any = 'Info', msg: any = ''): void {
        //#CC6331 background color
        Swal.fire({
            title: title,
            text: msg,
            icon: 'info',
            confirmButtonColor: '#3085d6',
            confirmButtonText: this._translocoService.translate('close'),
        }).then((result) => {});
    }
    public showMessagewarning(title: any = 'Warning', msg: any = ''): void {
        Swal.fire({
            title: title,
            text: msg,
            icon: 'warning',
            confirmButtonColor: '#3085d6',
            confirmButtonText: this._translocoService.translate('close'),
        }).then((result) => {});
    }
    public showMessageSuccess(title: any = 'Success', msg: any = ''): void {
        Swal.fire({
            title: title,
            text: msg,
            icon: 'success',
            confirmButtonColor: '#3085d6',
            confirmButtonText: this._translocoService.translate('close'),
        }).then((result) => {});
    }
    public beforesave(): void {}
    public aftersavefail(): void {}
    public aftersave(): void {}
    public baseInitData(): void {
        this.save(true);
    }

    public getFontAwesomeIconFromMIME(mimeType) {
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
    public formatSizeUnits(bytes) {
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
    save(first_submit: boolean = true): void {
        this.beforesave();
        this.loading = true;
        if (this.actionEnum == 1) {
            this.http
                .post(this.controller + '.ctr/create/', {
                    data: this.record,
                })
                .subscribe(
                    (resp) => {
                        this.record = resp as T;
                        this.Oldrecord = this.record;
                        // this.basedialogRef.close(this.record);
                        Swal.fire(
                            this._translocoService.translate(
                                'common.thanh_cong'
                            ),
                            '',
                            'success'
                        );
                        this.aftersave();
                        this.actionEnum = 3;
                        this.loading = false;
                        this.errorModel = [];
                    },
                    (error) => {
                        if (error.status == 400) {
                            this.errorModel = error.error;
                            this.aftersavefail();
                            if (first_submit == true) {
                            } else {
                                Swal.fire(
                                    this._translocoService.translate(
                                        'common.canh_bao'
                                    ),
                                    this._translocoService.translate(
                                        'common.thong_tin_chua_chinh_xac'
                                    ),
                                    'warning'
                                );
                            }
                        }
                        if (error.status == 403) {
                            this.basedialogRef.close();
                            Swal.fire(
                                this._translocoService.translate(
                                    'common.no_permission'
                                ),
                                '',
                                'warning'
                            );
                        }
                        this.loading = false;
                    }
                );
        } else if (this.actionEnum == 2) {
            this.http
                .post(this.controller + '.ctr/edit/', {
                    data: this.record,
                })
                .subscribe(
                    (resp) => {
                        this.record = resp as T;
                        this.Oldrecord = this.record;
                        // this.basedialogRef.close(this.record);
                        Swal.fire(
                            this._translocoService.translate(
                                'common.thanh_cong'
                            ),
                            '',
                            'success'
                        );
                        this.aftersave();
                        this.actionEnum = 3;
                        this.loading = false;
                        this.errorModel = [];
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
                                    'common.common.no_permission'
                                ),
                                '',
                                'warning'
                            );
                        }
                        this.loading = false;
                    }
                );
        } else if (this.actionEnum == 4) {
            this.http
                .post(this.controller + '.ctr/copy/', {
                    data: this.record,
                })
                .subscribe(
                    (resp) => {
                        this.record = resp as T;
                        this.basedialogRef.close(this.record);
                        this.aftersave();
                    },
                    (error) => {
                        if (error.status == 400) {
                            this.errorModel = error.error;
                        }
                        if (error.status == 403) {
                            Swal.fire(
                                this._translocoService.translate(
                                    'common.no_permission'
                                ),
                                '',
                                'warning'
                            );
                        }
                        this.loading = false;
                    }
                );
        }
    }

    close(): void {
        if (this.actionEnum == 3) {
            this.basedialogRef.close(this.record);
        } else {
            this.basedialogRef.close(this.Oldrecord);
        }
    }
}
