import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import vi from '@angular/common/locales/en';
registerLocaleData(vi);
import { NZ_I18N, vi_VN } from 'ng-zorro-antd/i18n';
import { commonModule } from '@fuse/components/commonComponent/common.module';
import { common_pageModule } from '@fuse/components/commonComponent/common_page.module';
import { FuseCardModule } from '@fuse/components/card';
import { TranslocoModule } from '@ngneat/transloco';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FullCalendarModule } from '@fullcalendar/angular';
import { FusePipesModule } from '@fuse/pipes/pipes.module';
import { MaterialModule } from './material.module';
import { NgZorroAntdModule } from './ng-zorro-antd.module';
registerLocaleData(vi);
@NgModule({
    providers: [{ provide: NZ_I18N, useValue: vi_VN }],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        commonModule,
        common_pageModule,
        MaterialModule,
        NgZorroAntdModule,
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        commonModule,
        common_pageModule,
        FuseCardModule,
        TranslocoModule,
        commonModule,
        MatSidenavModule,
        FullCalendarModule,
        FusePipesModule,
        MaterialModule,
        NgZorroAntdModule,
    ],
})
export class SharedModule {}
