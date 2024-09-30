import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { sys_san_pham_popupAddComponent } from './popupAdd.component';
import { TranslocoService } from '@ngneat/transloco';
import { SeoService } from '@fuse/services/seo.service';
import { BaseIndexDatatableComponent } from 'app/Basecomponent/BaseIndexDatatable.component';
import { FuseNavigationService } from '@fuse/components/navigation';
import Swal from 'sweetalert2';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';

@Component({
    selector: 'sys_san_pham_index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss'],
})
export class sys_san_pham_indexComponent extends BaseIndexDatatableComponent {
    public list_status_del: sys_common_number_model[] = [];
    public list_loai_san_pham: sys_common_number_model[] = [];
    public list_nhan_hieu: sys_common_number_model[] = [];
    public file: any;
    constructor(
        public seoService: SeoService,
        public translocoService: TranslocoService,
        public route: ActivatedRoute,
        public http: HttpClient,
        public dialog: MatDialog,
        public _fuseNavigationService: FuseNavigationService,
        @Inject('BASE_URL') public BASE_URL: string
    ) {
        super(
            http,
            BASE_URL,
            translocoService,
            _fuseNavigationService,
            route,
            dialog,
            'sys_san_pham',
            {
                search: '',
                status_del: 1,
                id_nhan_hieu: -1,
                id_loai_san_pham: -1,
            }
        );
        this.baseInitData();
        this.get_list_loai_san_pham();
        this.get_list_nhan_hieu();
        this.list_status_del = [
            {
                id: 1,
                name: this._translocoService.translate('common.use'),
            },
            {
                id: 2,
                name: this._translocoService.translate('common.no_user'),
            },
        ];
    }
    get_list_loai_san_pham() {
        this.http
            .post('sys_loai_san_pham.ctr/getListUse', {})
            .subscribe((data) => {
                this.list_loai_san_pham = data as sys_common_number_model[];
                this.list_loai_san_pham.splice(0, 0);
            });
    }
    get_list_nhan_hieu() {
        this.http.post('sys_nhan_hieu.ctr/getListUse', {}).subscribe((data) => {
            this.list_nhan_hieu = data as sys_common_number_model[];
            this.list_nhan_hieu.splice(0, 0);
        });
    }
    ngOnInit() {
        var title =
            'CuaSneaker - ' +
            this.translocoService.translate('NAV.sys_san_pham');
        var metaTag = [
            {
                property: 'og:url',
                content: 'https://i.ibb.co/FnnkQCL/Logo.jpg',
            },
            {
                property: 'og:title',
                content: title,
            },
            {
                property: 'og:image',
                content: '../assets/images/common/images/img_2807.png',
            },
            {
                property: 'og:description',
                content: '',
            },
        ];
        this.seoService.updateTitle(title);
        this.seoService.updateMetaTags(metaTag);
    }
    openDialogAdd() {
        const dialog = this.dialog.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: {
                actionEnum: 1,
                db: {
                    id: 0,
                },
            },
        });
        dialog.afterClosed().subscribe((data) => {
            if (data.db.id == 0) return;
            this.rerender();
        });
    }
    openDialogEdit(model: any, pos: any) {
        model.actionEnum = 2;
        const dialog = this.dialog.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialog.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
    onFileSelected(event: any): void {
        this.file = event.target.files[0];
    }
    downloadTemplate() {
        var url = this.controller + '.ctr/downloadTemp';
        window.location.href = url;
    }
    onSubmitFile(event: any) {
        if (this.file == null || this.file == undefined) {
            this.showMessagewarning('Phải chọn file import đơn vị tính');
        } else {
            this.showLoading();
            var formData = new FormData();
            formData.append('file', this.file);
            this.http
                .post(this.controller + '.ctr/ImportFormExcel', formData)
                .subscribe((data) => {
                    Swal.close();
                    var resutl = data;
                    if (resutl == '1') {
                        this.showMessageSuccess();
                        this.rerender();
                    } else if (resutl == '-1') {
                        this.showMessagewarning('File không đúng định dạng');
                    } else {
                        this.showMessageErrorImport(data);
                    }
                });
        }
    }
    exportToExcel() {
        this.showLoading();
        const params = new HttpParams()
            .set('search', this.filter.search)
            .set('status_del', this.filter.status_del)
            .set('id_loai_san_pham', this.filter.id_loai_san_pham)
            .set('id_nhan_hieu', this.filter.id_nhan_hieu);
        let url = this.controller + '.ctr/exportToExcel';
        this.http
            .get(url, { params, responseType: 'blob', observe: 'response' })
            .subscribe((resp) => {
                var data = resp;
                var downloadFile = new Blob([data.body], {
                    type: data.body.type,
                });
                const a = document.createElement('a');
                a.setAttribute('style', 'display: none;');
                document.body.appendChild(a);
                a.href = URL.createObjectURL(downloadFile);
                a.target = '_dAblank';
                a.download = 'SanPham.xlsx';
                a.click();
                document.body.removeChild(a);
                Swal.close();
            });
    }
}
