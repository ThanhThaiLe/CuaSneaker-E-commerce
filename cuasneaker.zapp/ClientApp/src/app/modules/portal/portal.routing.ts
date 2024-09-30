import { Route } from '@angular/router';
import { HomePageComponent } from './portal-home-page/home.component';
import { PortalSanPhamPageComponent } from './portal-san-pham/portal_san_pham.component';
import { PortalShoppingCardComponent } from './portal-shopping-card/portal-shopping-card.component';
import { PortalPaymentComponent } from './portal-payment/portal-payment.component';
import { PortalGioiThieuComponent } from './portal-gioi-thieu/portal-gioi-thieu.component';
import { PortalContactUsComponent } from './portal-contact-us/portal-contact-us.component';
import { PortalProductDetailComponent } from './portal-product-detail/portal_product_detail.component';

export const portalroutes: Route[] = [
    {
        path: 'homepage-index',
        component: HomePageComponent,
    },
    {
        path: 'portal-product-detail/:name',
        component: PortalProductDetailComponent,
    },
    {
        path: 'portal-gioi-thieu',
        component: PortalGioiThieuComponent,
    },
    {
        path: 'portal-contact-us',
        component: PortalContactUsComponent,
    },
    {
        path: 'portal-payment',
        component: PortalPaymentComponent,
    },
    // {
    //     path: 'portal-san-pham',
    //     component: PortalSanPhamPageComponent,
    // },
    {
        path: 'portal-san-pham/:name',
        component: PortalSanPhamPageComponent,
    },

    {
        path: 'portal-shopping-card',
        component: PortalShoppingCardComponent,
    },
];
