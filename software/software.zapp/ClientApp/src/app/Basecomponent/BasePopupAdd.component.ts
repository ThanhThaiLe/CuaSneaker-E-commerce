import { Directive } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';

import { TranslocoService } from '@ngneat/transloco';
import { FuseNavigationService } from '@fuse/components/navigation';

@Directive()
export abstract class BasePopUpAddComponent {
    public Oldrecord: any;
    public record: any;
    public errorModel: any;
    public actionEnum: number;
    public baseurl: String;
    public pageLoading: Boolean = false;
    public loading: boolean = false;
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
    public showLoading(title: any, html: any, showClose: boolean) {
        if (title == '')
            title = this._translocoService.translate('system.vui_long_doi');
        if (html == '')
            html = this._translocoService.translate('system.dang_tai_du_lieu');
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

    public showMessageinfo(title: any = 'Thông báo', msg: any = ''): void {
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
        this.save();
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
    removeVietnameseTones(str) {
        str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, 'a');
        str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, 'e');
        str = str.replace(/ì|í|ị|ỉ|ĩ/g, 'i');
        str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, 'o');
        str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, 'u');
        str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, 'y');
        str = str.replace(/đ/g, 'd');
        str = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, 'a');
        str = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, 'e');
        str = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, 'i');
        str = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, 'o');
        str = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, 'u');
        str = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, 'y');
        str = str.replace(/Đ/g, 'd');
        // Some system encode vietnamese combining accent as individual utf-8 characters
        // Một vài bộ encode coi các dấu mũ, dấu chữ như một kí tự riêng biệt nên thêm hai dòng này
        str = str.replace(/\u0300|\u0301|\u0303|\u0309|\u0323/g, ''); // ̀ ́ ̃ ̉ ̣  huyền, sắc, ngã, hỏi, nặng
        str = str.replace(/\u02C6|\u0306|\u031B/g, ''); // ˆ ̆ ̛  Â, Ê, Ă, Ơ, Ư
        // Remove extra spaces
        // Bỏ các khoảng trắng liền nhau
        str = str.replace(/ + /g, ' ');
        str = str.trim();
        // Remove punctuations
        // Bỏ dấu câu, kí tự đặc biệt
        str = str.replace(
            /!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'|\"|\&|\#|\[|\]|~|\$|_|`|-|{|}|\||\\/g,
            ' '
        );
        str = str.toLowerCase();
        return str;
    }
    save(): void {
        this.beforesave();
        this.loading = true;
        if (this.actionEnum == 1) {
            this.http
                .post(this.controller + '.ctr/create/', {
                    data: this.record,
                })
                .subscribe(
                    (resp) => {
                        this.record = resp;
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
                                    'no_permission'
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
                        this.record = resp;
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
                                    'common.no_permission'
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
                        this.record = resp;
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
