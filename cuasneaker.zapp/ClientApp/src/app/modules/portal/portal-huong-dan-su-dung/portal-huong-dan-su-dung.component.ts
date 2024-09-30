import { Component, OnInit } from '@angular/core';
import { SeoService } from '@fuse/services/seo.service';
import { TranslocoService } from '@ngneat/transloco';

@Component({
    selector: 'app-portal-huong-dan-su-dung',
    templateUrl: './portal-huong-dan-su-dung.component.html',
    styleUrls: ['./portal-huong-dan-su-dung.component.scss'],
})
export class PortalHuongDanSuDungComponent implements OnInit {
    constructor(
        public seoService: SeoService,
        public translocoService: TranslocoService
    ) {}

    ngOnInit(): void {
        var title =
            'CuaSneaker - ' +
            this.translocoService.translate('portal.huong_dan_su_dung');
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
