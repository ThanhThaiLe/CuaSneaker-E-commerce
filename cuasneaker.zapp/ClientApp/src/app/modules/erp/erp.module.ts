import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
import { commonModule } from '@fuse/components/commonComponent/common.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { erproutes } from './erp.routing';
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
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { FuseFindByKeyPipeModule } from '@fuse/pipes/find-by-key';
import { A11yModule } from '@angular/cdk/a11y';
import { PortalModule } from '@angular/cdk/portal';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { SwiperModule } from 'swiper/angular';
import { erp_nhap_kho_popupAddComponent } from './erp-nhap-kho/popupAdd.component';
import { erp_nhap_kho_indexComponent } from './erp-nhap-kho/index.component';
import { erp_xuat_kho_indexComponent } from './erp-xuat-kho/index.component';
import { erp_xuat_kho_popupAddComponent } from './erp-xuat-kho/popupAdd.component';
import { erp_loai_nhap_xuat_indexComponent } from './erp-loai-nhap_xuat/index.component';
import { erp_loai_nhap_xuat_popupAddComponent } from './erp-loai-nhap_xuat/popupAdd.component';
import { erp_don_hang_ban_indexComponent } from './erp-don-hang-ban/index.component';
import { erp_don_hang_ban_popupAddComponent } from './erp-don-hang-ban/popupAdd.component';
import { erp_don_hang_mua_indexComponent } from './erp-don-hang-mua/index.component';
import { erp_don_hang_mua_popupAddComponent } from './erp-don-hang-mua/popupAdd.component';
import { erp_don_vi_van_chuyen_indexComponent } from './erp-don-vi-van-chuyen/index.component';
import { erp_don_vi_van_chuyen_popupAddComponent } from './erp-don-vi-van-chuyen/popupAdd.component';
import { erp_don_hang_ban_popupAddChooseProductComponent } from './erp-don-hang-ban/popupAddChooseProduct.component';
@NgModule({
    declarations: [
        erp_don_hang_ban_popupAddChooseProductComponent,
        erp_nhap_kho_indexComponent,
        erp_nhap_kho_popupAddComponent,
        erp_xuat_kho_indexComponent,
        erp_xuat_kho_popupAddComponent,
        erp_don_hang_ban_indexComponent,
        erp_don_hang_ban_popupAddComponent,
        erp_don_hang_mua_indexComponent,
        erp_don_hang_mua_popupAddComponent,
        erp_loai_nhap_xuat_indexComponent,
        erp_loai_nhap_xuat_popupAddComponent,
        erp_don_vi_van_chuyen_indexComponent,
        erp_don_vi_van_chuyen_popupAddComponent,
    ],
    imports: [
        RouterModule.forChild(erproutes),
        SwiperModule,
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
export class ErpModule {}
