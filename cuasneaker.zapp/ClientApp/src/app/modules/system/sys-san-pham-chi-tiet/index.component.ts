import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { sys_san_pham_chi_tiet_popupAddComponent } from './popupAdd.component';
import { TranslocoService } from '@ngneat/transloco';
import { SeoService } from '@fuse/services/seo.service';
import { BaseIndexDatatableComponent } from 'app/Basecomponent/BaseIndexDatatable.component';
import { FuseNavigationService } from '@fuse/components/navigation';
import Swal from 'sweetalert2';
import { sys_san_pham_popupAddComponent } from '../sys-san-pham/popupAdd.component';
import { sys_san_pham_chi_tiet_model } from './sys-san-pham-chi-tiet.types';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { cm_file_upload_popupComponent } from '@fuse/components/commonComponent/cm_file_upload/cm_file_upload_popup.component';
import { popupImagesComponent } from './popupImages.component';

@Component({
    selector: 'sys_san_pham_chi_tiet_index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss'],
})
export class sys_san_pham_chi_tiet_indexComponent extends BaseIndexDatatableComponent {
    public list_status_del: sys_common_number_model[] = [];
    public list_size: sys_common_number_model[] = [];
    public list_color: sys_common_number_model[] = [];
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
            'sys_san_pham_chi_tiet',
            {
                search: '',
                status_del: 1,
                id_size: -1,
                id_color: -1,
            }
        );
        this.baseInitData();
        this.get_list_size();
        this.get_list_color();
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
    get_list_size() {
        this.http.post('sys_size.ctr/getListUse', {}).subscribe((data) => {
            this.list_size = data as sys_common_number_model[];
            this.list_size.splice(0, 0, this.all);
        });
    }
    get_list_color() {
        this.http.post('sys_color.ctr/getListUse', {}).subscribe((data) => {
            this.list_color = data as sys_common_number_model[];
            this.list_color.splice(0, 0, this.all);
        });
    }
    ngOnInit() {
        var title =
            'CuaSneaker - ' +
            this.translocoService.translate('NAV.sys_san_pham_chi_tiet');
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
    openDialogFileUpload(model: sys_san_pham_chi_tiet_model) {
        var item = {
            actionEnum: 1,
            controller: this.controller.toString(),
            db: {
                id: model.db.id,
            },
            list_file: model.list_file,
        };
        const dialog = this.dialog.open(popupImagesComponent, {
            disableClose: true,
            width: '850px',
            data: item,
        });
        dialog.afterClosed().subscribe((data) => {
            this.rerender();
        });
    }
    openDialogAdd() {
        const dialog = this.dialog.open(
            sys_san_pham_chi_tiet_popupAddComponent,
            {
                disableClose: true,
                width: '850px',
                data: {
                    actionEnum: 1,
                    db: {
                        id: 0,
                    },
                },
            }
        );
        dialog.afterClosed().subscribe((data) => {
            if (data.db.id == 0) return;
            this.rerender();
        });
    }
    openDialogEdit(model: any, pos: any) {
        model.actionEnum = 2;
        const dialog = this.dialog.open(
            sys_san_pham_chi_tiet_popupAddComponent,
            {
                disableClose: true,
                width: '850px',
                data: model,
            }
        );
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialog.open(
            sys_san_pham_chi_tiet_popupAddComponent,
            {
                disableClose: true,
                width: '850px',
                data: model,
            }
        );
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
    openDialogDetailSanPham(id_san_pham: any) {
        var model = {
            actionEnum: 3,
            db: {
                id: id_san_pham,
            },
        };
        const dialog = this.dialog.open(sys_san_pham_popupAddComponent, {
            disableClose: true,
            width: '850px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {});
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
            .set('status_del', this.filter.status_del.toString());

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
