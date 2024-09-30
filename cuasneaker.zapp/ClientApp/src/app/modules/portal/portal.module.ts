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
import { portalroutes } from './portal.routing';
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
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
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
import { HomePageComponent } from './portal-home-page/home.component';
import { SwiperModule } from 'swiper/angular';
import { PortalSanPhamPageComponent } from './portal-san-pham/portal_san_pham.component';
import { PortalShoppingCardComponent } from './portal-shopping-card/portal-shopping-card.component';
import { PortalContactUsComponent } from './portal-contact-us/portal-contact-us.component';
import { PortalGioiThieuComponent } from './portal-gioi-thieu/portal-gioi-thieu.component';
import { PortalHuongDanSuDungComponent } from './portal-huong-dan-su-dung/portal-huong-dan-su-dung.component';
import { PortalPaymentComponent } from './portal-payment/portal-payment.component';
import { PortalProductDetailComponent } from './portal-product-detail/portal_product_detail.component';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { RxState } from '@rx-angular/state';
import { CARD_STATE, CardState } from '../common-model/states/card.state';
import { FlashSaleComponent } from './portal-home-page/flash-sale/flash-sale.component';
import { SneakerManComponent } from './portal-home-page/sneaker-man/sneaker-man.component';
import { SneakerWomanComponent } from './portal-home-page/sneaker-woman/sneaker-woman.component';
import { NhanHieuComponent } from './portal-home-page/nhan-hieu/nhan-hieu.component';
import { LeaderShipComponent } from './portal-home-page/leader-ship/leader-ship.component';
import { SliderMainComponent } from './portal-home-page/slider-main/slider-main.component';
import { SliderSecondComponent } from './portal-home-page/slider-second/slider-second.component';
import { GirdProductsComponent } from './portal-home-page/gird-products/gird-products.component';
import { DataBuyProductsComponent } from './portal-home-page/data-buy-products/data-buy-products.component';
import { SliderGridDataComponent } from './portal-home-page/slider-grid-data/slider-grid-data.component';
@NgModule({
    providers: [
        {
            provide: CARD_STATE,
            useFactory: () => new RxState<CardState>(),
        },
        ToastrService,
    ],
    declarations: [
        HomePageComponent,
        PortalSanPhamPageComponent,
        PortalShoppingCardComponent,
        PortalContactUsComponent,
        PortalGioiThieuComponent,
        PortalHuongDanSuDungComponent,
        PortalPaymentComponent,
        PortalProductDetailComponent,
        FlashSaleComponent,
        SneakerManComponent,
        SneakerWomanComponent,
        NhanHieuComponent,
        LeaderShipComponent,
        SliderMainComponent,
        SliderSecondComponent,
        GirdProductsComponent,
        DataBuyProductsComponent,
        SliderGridDataComponent,
    ],
    imports: [
        RouterModule.forChild(portalroutes),
        SwiperModule,
        ToastrModule.forRoot({
            positionClass: 'toast-top-right',
        }),
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
export class PortalHomeModule {}
