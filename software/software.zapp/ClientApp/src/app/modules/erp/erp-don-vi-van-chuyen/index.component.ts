import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { erp_don_vi_van_chuyen_popupAddComponent } from './popupAdd.component';
import { TranslocoService } from '@ngneat/transloco';
import { SeoService } from '@fuse/services/seo.service';
import { BaseIndexDatatableComponent } from 'app/Basecomponent/BaseIndexDatatable.component';
import { FuseNavigationService } from '@fuse/components/navigation';
import Swal from 'sweetalert2';

@Component({
    selector: 'erp_don_vi_van_chuyen_index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss'],
})
export class erp_don_vi_van_chuyen_indexComponent extends BaseIndexDatatableComponent {
    public list_status_del: any;
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
            'erp_don_vi_van_chuyen',
            {
                search: '',
                status_del: 1,
            }
        );
        this.baseInitData();
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
    openDialogAdd() {
        const dialog = this.dialog.open(
            erp_don_vi_van_chuyen_popupAddComponent,
            {
                disableClose: true,
                width: '768px',
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
            erp_don_vi_van_chuyen_popupAddComponent,
            {
                disableClose: true,
                width: '768px',
                data: model,
            }
        );
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
            this.rerender();
        });
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialog.open(
            erp_don_vi_van_chuyen_popupAddComponent,
            {
                disableClose: true,
                width: '768px',
                data: model,
            }
        );
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
            this.rerender();
        });
    }
    ngOnInit() {
        var title =
            'CuaSneaker - ' +
            this.translocoService.translate('NAV.erp_don_vi_van_chuyen');
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
                        this.showMessageSuccess('Import dữ liệu thành công');
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
                a.download = 'DonViTinh.xlsx';
                a.click();
                document.body.removeChild(a);
                Swal.close();
            });
    }
}
