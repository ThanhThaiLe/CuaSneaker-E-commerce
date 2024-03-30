import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { sys_banner_popupAddComponent } from './popupAdd.component';
import { TranslocoService } from '@ngneat/transloco';
import { SeoService } from '@fuse/services/seo.service';
import { BaseIndexDatatableComponent } from 'app/Basecomponent/BaseIndexDatatable.component';
import { FuseNavigationService } from '@fuse/components/navigation';

@Component({
    selector: 'sys_banner_index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss'],
})
export class sys_banner_indexComponent extends BaseIndexDatatableComponent {
    public list_status_del: any = [];
    public list_type_banner: any = [];
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
            'sys_banner',
            {
                search: '',
                status_del: 1,
                id_type: 1,
            }
        );
        this.baseInitData();
        this.list_status_del = [
            {
                id: '1',
                name: this._translocoService.translate('common.use'),
            },
            {
                id: '2',
                name: this._translocoService.translate('common.no_user'),
            },
        ];
        this.list_type_banner = [
            {
                id: '1',
                name: this._translocoService.translate('system.trang_chu'),
            },
            {
                id: '2',
                name: this._translocoService.translate('system.san_pham'),
            },
        ];
    }
    ngOnInit() {
        var title =
            'CuaSneaker - ' + this.translocoService.translate('NAV.sys_banner');
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
        const dialog = this.dialog.open(sys_banner_popupAddComponent, {
            disableClose: true,
            width: '768px',
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
        const dialog = this.dialog.open(sys_banner_popupAddComponent, {
            disableClose: true,
            width: '768px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialog.open(sys_banner_popupAddComponent, {
            disableClose: true,
            width: '768px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
        });
    }
}
