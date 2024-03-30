import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { sys_group_user_popupAddComponent } from './popupAdd.component';
import { TranslocoService } from '@ngneat/transloco';
import { SeoService } from '@fuse/services/seo.service';
import { BaseIndexDatatableComponent } from 'app/Basecomponent/BaseIndexDatatable.component';
import { FuseNavigationService } from '@fuse/components/navigation';

@Component({
    selector: 'sys_group_user_index',
    templateUrl: './index.component.html',
    styleUrls: ['./index.component.scss'],
})
export class sys_group_user_indexComponent extends BaseIndexDatatableComponent {
    public list_status_del: any;
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
            'sys_group_user',
            {
                search: '',
                status_del: 1,
            }
        );
        this.baseInitData();
        this.list_status_del = [
            {
                id: '1',
                name: this._translocoService.translate('system.user'),
            },
            {
                id: '2',
                name: this._translocoService.translate('system.no_user'),
            },
        ];
    }
    openDialogAdd() {
        const dialog = this.dialog.open(sys_group_user_popupAddComponent, {
            disableClose: true,
            width: '768px',
            data: {
                actionEnum: 1,
                db: {
                    id: 0,
                },
                list_item: [],
                list_role: [],
            },
        });
        dialog.afterClosed().subscribe((data) => {
            if (data.db.id == 0) return;
            this.rerender();
        });
    }
    openDialogEdit(model: any, pos: any) {
        model.actionEnum = 2;
        const dialog = this.dialog.open(sys_group_user_popupAddComponent, {
            disableClose: true,
            width: '768px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
            this.rerender();
        });
    }
    openDialogDetail(model: any, pos: any) {
        model.actionEnum = 3;
        const dialog = this.dialog.open(sys_group_user_popupAddComponent, {
            disableClose: true,
            width: '768px',
            data: model,
        });
        dialog.afterClosed().subscribe((data) => {
            if (data != undefined && data != null) this.listData[pos] = data;
            this.rerender();
        });
    }
    ngOnInit() {
        var title =
            'CuaSneaker - ' +
            this.translocoService.translate('NAV.sys_group_user');
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
}
