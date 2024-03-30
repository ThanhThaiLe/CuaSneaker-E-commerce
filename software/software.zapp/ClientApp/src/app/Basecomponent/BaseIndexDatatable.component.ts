import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { Directive, OnDestroy, QueryList, ViewChildren } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import Swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router';
import { FuseNavigationService } from '@fuse/components/navigation';
import { TranslocoService } from '@ngneat/transloco';
import { DataTablesResponse } from 'app/Basecomponent/datatable';

@Directive()
export abstract class BaseIndexDatatableComponent implements OnDestroy {
    public action: string;
    public controller: String;
    public filter: any;
    public table: any;
    @ViewChildren(DataTableDirective) dtElements: QueryList<DataTableDirective>;
    public pageLoading: Boolean = false;
    public dtOptions: DataTables.Settings = {};
    public currentIndex: number;
    public listData: any = [];
    public total: any = [];
    public baseurl: String;
    public all = {
        id: -1,
        name: this._translocoService.translate('common.all'),
    };
    constructor(
        public http: HttpClient,
        _baseUrl: string,
        public _translocoService: TranslocoService,
        public _fuseNavigationService: FuseNavigationService,
        public route: ActivatedRoute,
        public dialog: MatDialog,
        _controller: String,
        _filter: any
    ) {
        this.controller = _controller;
        this.baseurl = _baseUrl;
        this.filter = _filter;
        this.pageLoading = false;
        $(document).on(
            'click',
            '.mat-focus-indicator.mat-icon-button.mat-button-base, .mat-tab-label',
            () =>
                setTimeout(() => {
                    if (this.dtElements.length > 0) {
                        this.dtElements.forEach(
                            (dtElement: DataTableDirective) => {
                                dtElement.dtInstance.then(
                                    (dtInstance: DataTables.Api) => {
                                        dtInstance.columns.adjust();
                                    }
                                );
                            }
                        );
                    }
                }, 500)
        );
    }
    ngOnDestroy(): void {}
    public rerender(): void {
        this.handleDataBefore();
        this.dtElements.forEach((dtElement: DataTableDirective) => {
            dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
                dtInstance.ajax.reload(null, true);
            });
        });
        // Destroy the table first
    }
    public getStartOfMonth(date: Date): Date {
        var month = date.getMonth();
        var year = date.getFullYear();
        return new Date(year, month, 1);
    }
    public getEndOfMonth(date: Date): Date {
        var month = date.getMonth();
        var year = date.getFullYear();
        if (month == 12) {
            return new Date(year, month, 31);
        }
        return new Date(year, month + 1, 0);
    }
    public showLoading(
        title: any = '',
        html: any = '',
        showClose: boolean = true
    ) {
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
            onBeforeOpen: () => {
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
    public showMessageErrorImport(
        title: any = 'Không thể nhập dữ liệu',
        msg: any = 'Vui lòng tải về xem chi tiết',
        path: any = ''
    ): void {
        Swal.fire({
            title: title,
            text: msg,
            icon: 'warning',
            confirmButtonColor: '#3085d6',
            confirmButtonText:
                this._translocoService.translate('common.download'),
            cancelButtonColor: '#3085d6',
            cancelButtonText: this._translocoService.translate('common.close'),
        }).then((result) => {
            if (result.value) {
                var url = 'sys_home.ctr/downloadtempFileError?path=' + path;
                window.location.href = url;
            }
        });
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
    public rerenderfilter(): void {
        this.before_filter();
        this.dtElements.forEach((dtElement: DataTableDirective) => {
            dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
                dtInstance.ajax.reload(null, true);
            });
        });
    }
    public before_filter(): void {}
    revertStatus(model, status_del): void {
        model.db.status_del = status_del;
        Swal.fire({
            title: this._translocoService.translate('common.areYouSure'),
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
                    .post(this.controller + '.ctr/edit/', { data: model })
                    .subscribe(
                        (resp) => {
                            if (status_del == 1)
                                this.showMessageSuccess(
                                    'Thông báo',
                                    'Đã sử dụng lại thành công'
                                );
                            else
                                this.showMessageSuccess(
                                    'Thông báo',
                                    'Đã ngưng sử dụng thành công'
                                );
                            this.rerender();
                        },
                        (error) => {
                            if (error.status == 403) {
                                Swal.fire(
                                    this._translocoService.translate(
                                        'common.no_permission'
                                    ),
                                    '',
                                    'warning'
                                );
                            }
                        }
                    );
            }
        });
    }
    public baseInitData(): void {
        this.handleDataBefore();
        const that = this;
        this.dtOptions = {
            language: {
                processing: 'Đang xử lý...',
                lengthMenu: 'Xem _MENU_ dòng',
                zeroRecords: 'Không tìm thấy dòng nào phù hợp',
                info: 'Đang xem _START_ đến _END_ trong tổng số _TOTAL_ dòng',
                infoEmpty: 'Đang xem 0 đến 0 trong tổng số 0 dòng',
                infoFiltered: '(được lọc từ _MAX_ mục)',
                search: 'Tìm:',
                paginate: {
                    first: 'Đầu',
                    previous: 'Trước',
                    next: 'Tiếp',
                    last: 'Cuối',
                },
            },

            scrollCollapse: true,
            retrieve: true,
            scrollX: true,
            responsive: true,
            dom: '<"top"pli>rt<"bottom"p><"clear">',
            ordering: false,
            serverSide: true,
            processing: true,
            lengthMenu: [25, 50, 100],
            drawCallback: function (settings) {
                var api = this.api();
                that.table = api;
                setTimeout(function () {
                    api.columns.adjust();
                }, 300);
                $('tbody').on('click', 'tr', function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('tr.selected').removeClass('selected');
                        $(this).addClass('selected');
                    }
                });
            },

            searching: false,
            ajax: (data, callback, settings) => {
                this.pageLoading = true;
                this.http
                    .post<DataTablesResponse>(
                        this.baseurl +
                            '' +
                            this.controller +
                            '.ctr/DataHandler/',
                        {
                            param: data,
                            data: this.filter,
                        }
                    )
                    .subscribe((resp) => {
                        var data: any;
                        data = resp;
                        that.listData = resp.data;
                        this.pageLoading = false;
                        that.total = data.total;
                        that.currentIndex = resp.start;
                        callback({
                            recordsTotal: resp.recordsTotal,
                            recordsFiltered: resp.recordsFiltered,
                            data: [],
                        });
                    });
            },
        };
    }

    public baseInitDataParam(): void {
        this.handleDataBefore();
        const that = this;
        this.dtOptions = {
            language: {
                processing: 'Đang xử lý...',
                lengthMenu: 'Xem _MENU_ dòng',
                zeroRecords: 'Không tìm thấy dòng nào phù hợp',
                info: 'Đang xem _START_ đến _END_ trong tổng số _TOTAL_ dòng',
                infoEmpty: 'Đang xem 0 đến 0 trong tổng số 0 dòng',
                infoFiltered: '(được lọc từ _MAX_ mục)',
                search: 'Tìm:',
                paginate: {
                    first: 'Đầu',
                    previous: 'Trước',
                    next: 'Tiếp',
                    last: 'Cuối',
                },
            },

            scrollCollapse: true,
            retrieve: true,
            scrollX: true,
            responsive: true,
            dom: '<"top"pli>rt<"bottom"p><"clear">',
            ordering: false,
            serverSide: true,
            processing: true,
            lengthMenu: [50, 75, 100],
            drawCallback: function (settings) {
                var api = this.api();
                that.table = api;
                setTimeout(function () {
                    api.columns.adjust();
                }, 300);
                $('tbody').on('click', 'tr', function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    } else {
                        $('tr.selected').removeClass('selected');
                        $(this).addClass('selected');
                    }
                });
            },

            searching: false,
            ajax: (data, callback, settings) => {
                this.pageLoading = true;

                this.http
                    .post<DataTablesResponse>(
                        this.baseurl +
                            '' +
                            this.controller +
                            '.ctr/DataHandler/',
                        {
                            param1: data,
                            data: this.filter,
                        }
                    )
                    .subscribe((resp) => {
                        var data: any;
                        data = resp;
                        that.listData = data.data;
                        that.total = data.total;
                        this.pageLoading = false;
                        that.currentIndex = resp.start;
                        callback({
                            recordsTotal: resp.recordsTotal,
                            recordsFiltered: resp.recordsFiltered,
                            data: [],
                        });
                    });
            },
        };
    }

    public handleDataBefore(): void {}
}
