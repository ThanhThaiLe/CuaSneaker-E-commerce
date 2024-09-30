import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { sys_group_user_indexComponent } from './sys-group-user/index.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatBadgeModule } from '@angular/material/badge';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import {
    MatCommonModule,
    MatNativeDateModule,
    MatRippleModule,
} from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatStepperModule } from '@angular/material/stepper';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTreeModule } from '@angular/material/tree';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { TranslocoModule } from '@ngneat/transloco';
import { DataTablesModule } from 'angular-datatables';
import { sys_group_user_popupAddComponent } from './sys-group-user/popupAdd.component';
import { commonModule } from '@fuse/components/commonComponent/common.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { systemroutes } from './system.routing';
import { FullCalendarModule } from '@fullcalendar/angular';
import { FuseDateRangeModule } from '@fuse/components/date-range';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { EditorModule } from '@tinymce/tinymce-angular';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { NzEmptyModule } from 'ng-zorro-antd/empty';
import { FusePipesModule } from '@fuse/pipes/pipes.module';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { SharedModule } from 'app/shared/shared.module';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { NgApexchartsModule } from 'ng-apexcharts';
import { AgmCoreModule } from '@agm/core';
import { NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import { NzProgressModule } from 'ng-zorro-antd/progress';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { FuseMasonryModule } from '@fuse/components/masonry';
import { ContactsDetailsComponent } from './sys-khach-hang/details/details.component';
import { ContactsListComponent } from './sys-khach-hang/list/list.component';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { FuseFindByKeyPipeModule } from '@fuse/pipes/find-by-key';
import { A11yModule } from '@angular/cdk/a11y';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { sys_loai_san_pham_indexComponent } from './sys-loai-san-pham/index.component';
import { sys_loai_san_pham_popupAddComponent } from './sys-loai-san-pham/popupAdd.component';
import { sys_nhan_hieu_indexComponent } from './sys-nhan-hieu/index.component';
import { sys_nhan_hieu_popupAddComponent } from './sys-nhan-hieu/popupAdd.component';
import { sys_don_vi_tinh_indexComponent } from './sys-don-vi-tinh/index.component';
import { sys_don_vi_tinh_popupAddComponent } from './sys-don-vi-tinh/popupAdd.component';
import { sys_san_pham_indexComponent } from './sys-san-pham/index.component';
import { sys_san_pham_popupAddComponent } from './sys-san-pham/popupAdd.component';
import { sys_banner_indexComponent } from './sys-banner/index.component';
import { sys_banner_popupAddComponent } from './sys-banner/popupAdd.component';
import { sys_kho_indexComponent } from './sys-kho/index.component';
import { sys_kho_popupAddComponent } from './sys-kho/popupAdd.component';
import { sys_quoc_gia_indexComponent } from './sys-quoc-gia/index.component';
import { sys_quoc_gia_popupAddComponent } from './sys-quoc-gia/popupAdd.component';
import { sys_quan_huyen_indexComponent } from './sys-quan-huyen/index.component';
import { sys_quan_huyen_popupAddComponent } from './sys-quan-huyen/popupAdd.component';
import { sys_tinh_thanh_indexComponent } from './sys-tinh-thanh/index.component';
import { sys_tinh_thanh_popupAddComponent } from './sys-tinh-thanh/popupAdd.component';
import { sys_type_mail_indexComponent } from './sys-type-mail/index.component';
import { sys_type_mail_popupAddComponent } from './sys-type-mail/popupAdd.component';
import { sys_template_mail_indexComponent } from './sys-template-mail/index.component';
import { sys_template_mail_popupAddComponent } from './sys-template-mail/popupAdd.component';
import { sys_color_indexComponent } from './sys-color/index.component';
import { sys_color_popupAddComponent } from './sys-color/popupAdd.component';
import { sys_size_indexComponent } from './sys-size/index.component';
import { sys_size_popupAddComponent } from './sys-size/popupAdd.component';
import { sys_san_pham_chi_tiet_indexComponent } from './sys-san-pham-chi-tiet/index.component';
import { sys_san_pham_chi_tiet_popupAddComponent } from './sys-san-pham-chi-tiet/popupAdd.component';
import { sys_dieu_khoan_indexComponent } from './sys-dieu-khoan/index.component';
import { sys_dieu_khoan_popupAddComponent } from './sys-dieu-khoan/popupAdd.component';
import { sys_lien_ket_indexComponent } from './sys-lien-ket/index.component';
import { sys_lien_ket_popupAddComponent } from './sys-lien-ket/popupAdd.component';
import { sys_thong_tin_website_indexComponent } from './sys-thong-tin-website/index.component';
import { sys_thong_tin_website_popupAddComponent } from './sys-thong-tin-website/popupAdd.component';
import { popupImagesComponent } from './sys-san-pham-chi-tiet/popupImages.component';
import { RxState } from '@rx-angular/state';
import { CARD_STATE, CardState } from '../common-model/states/card.state';
import { sys_vat_indexComponent } from './sys-vat/index.component';
import { sys_vat_popupAddComponent } from './sys-vat/popupAdd.component';
import { sys_ngan_hang_indexComponent } from './sys-ngan-hang/index.component';
import { sys_ngan_hang_popupAddComponent } from './sys-ngan-hang/popupAdd.component';
@NgModule({
    providers: [
        {
            provide: CARD_STATE,
            useFactory: () => new RxState<CardState>(),
        },
    ],
    declarations: [
        popupImagesComponent,
        sys_thong_tin_website_popupAddComponent,
        sys_thong_tin_website_indexComponent,
        sys_ngan_hang_popupAddComponent,
        sys_ngan_hang_indexComponent,
        sys_vat_popupAddComponent,
        sys_vat_indexComponent,
        sys_lien_ket_popupAddComponent,
        sys_lien_ket_indexComponent,
        sys_dieu_khoan_popupAddComponent,
        sys_dieu_khoan_indexComponent,
        sys_color_popupAddComponent,
        sys_color_indexComponent,
        sys_size_popupAddComponent,
        sys_size_indexComponent,
        sys_template_mail_popupAddComponent,
        sys_template_mail_indexComponent,
        sys_type_mail_indexComponent,
        sys_type_mail_popupAddComponent,
        sys_tinh_thanh_indexComponent,
        sys_tinh_thanh_popupAddComponent,
        sys_quan_huyen_indexComponent,
        sys_quan_huyen_popupAddComponent,
        sys_kho_indexComponent,
        sys_kho_popupAddComponent,
        sys_banner_indexComponent,
        sys_banner_popupAddComponent,
        sys_san_pham_indexComponent,
        sys_san_pham_popupAddComponent,
        sys_san_pham_chi_tiet_indexComponent,
        sys_san_pham_chi_tiet_popupAddComponent,
        sys_don_vi_tinh_indexComponent,
        sys_don_vi_tinh_popupAddComponent,
        sys_quoc_gia_indexComponent,
        sys_quoc_gia_popupAddComponent,
        sys_nhan_hieu_indexComponent,
        sys_nhan_hieu_popupAddComponent,
        sys_loai_san_pham_indexComponent,
        sys_loai_san_pham_popupAddComponent,
        ContactsListComponent,
        ContactsDetailsComponent,
        sys_group_user_indexComponent,
        sys_group_user_popupAddComponent,
    ],
    imports: [
        RouterModule.forChild(systemroutes),
        A11yModule,
        CdkStepperModule,
        CdkTableModule,
        CdkTreeModule,
        MatNativeDateModule,
        PortalModule,
        ScrollingModule,
        CommonModule,
        MatMomentDateModule,
        FuseFindByKeyPipeModule,
        FullCalendarModule,
        FuseDateRangeModule,
        SweetAlert2Module,
        NgxChartsModule,
        EditorModule,
        commonModule,
        FusePipesModule,
        NzEmptyModule,
        NzIconModule,
        SharedModule,
        NgApexchartsModule,
        NgCircleProgressModule.forRoot({
            radius: 100,
            outerStrokeWidth: 16,
            innerStrokeWidth: 8,
            outerStrokeColor: '#78C000',
            innerStrokeColor: '#C7E596',
            animationDuration: 300,
        }),
        AgmCoreModule.forRoot({
            apiKey: '',
            libraries: ['places'],
        }),
        NgxMatTimepickerModule,
        MatDividerModule,
        NzProgressModule,
        MatSidenavModule,
        FuseMasonryModule,
        DragDropModule,
        ReactiveFormsModule,
        FormsModule,
        DataTablesModule,
        MatAutocompleteModule,
        MatBadgeModule,
        MatBottomSheetModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatCommonModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatFormFieldModule,
        MatGridListModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatMenuModule,
        MatPaginatorModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRadioModule,
        MatRippleModule,
        MatSelectModule,
        NgxMatSelectSearchModule,
        MatSidenavModule,
        MatSlideToggleModule,
        MatSliderModule,
        MatSnackBarModule,
        MatSortModule,
        MatStepperModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        MatTreeModule,
        TranslocoModule,
    ],
    exports: [],
})
export class SystemModule {}
