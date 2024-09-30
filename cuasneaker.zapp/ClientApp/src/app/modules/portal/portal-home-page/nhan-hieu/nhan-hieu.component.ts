import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Data } from '@angular/router';
import { FuseConfigService } from '@fuse/services/config';
import { FuseMediaWatcherService } from '@fuse/services/media-watcher';
import { SeoService } from '@fuse/services/seo.service';
import { TranslocoService } from '@ngneat/transloco';
import { AppConfig } from 'app/core/config/app.config';
import { ShoppingCardsService } from 'app/layout/common/products-card/products-card.service';
import { sys_common_number_model } from 'app/modules/common-model/sys-common-model.types';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { InitialDataPortal } from '../../portal.types';
import * as AOS from 'aos';
@Component({
    selector: 'app-nhan-hieu',
    templateUrl: './nhan-hieu.component.html',
    styleUrls: ['./nhan-hieu.component.scss'],
})
export class NhanHieuComponent implements OnInit {
    data: InitialDataPortal;
    private _unsubscribeAll: Subject<any> = new Subject<any>();
    public isScreenSmall: any;
    public isScreenMobi: any;
    public activeLang: any;
    public config: AppConfig;
    public list_nhan_hieu: sys_common_number_model[] = [];
    constructor(
        public http: HttpClient,
        private _changeDetectorRef: ChangeDetectorRef,
        private _fuseConfigService: FuseConfigService,
        private _shopping_cardsService: ShoppingCardsService,
        public _translocoService: TranslocoService,
        private _router: Router,
        public seoService: SeoService,
        private _activatedRoute: ActivatedRoute,
        private _fuseMediaWatcherService: FuseMediaWatcherService
    ) {}

    ngOnInit(): void {
        this._fuseMediaWatcherService.onMediaChange$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(({ matchingAliases }) => {
                this.isScreenMobi = !matchingAliases.includes('md');
                this.isScreenSmall = !matchingAliases.includes('sm');
            });
        this._fuseConfigService.config$
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe((config: AppConfig) => {
                this.config = config;
            });
        this._translocoService.langChanges$.subscribe((activeLang) => {
            this.activeLang = activeLang;
        });
        var title =
            'CuaSneaker - ' +
            this._translocoService.translate('portal.trang_chu');
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
        // Subscribe to the resolved route data
        this._activatedRoute.data.subscribe((data: Data) => {
            this.data = data.initialDataPortal;
        });
        this.list_nhan_hieu = this.data.list_nhan_hieu;
        AOS.init({ duration: 1000 });
    }
}
