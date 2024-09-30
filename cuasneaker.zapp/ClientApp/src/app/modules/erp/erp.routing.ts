import { Route } from '@angular/router';
import { erp_nhap_kho_indexComponent } from './erp-nhap-kho/index.component';
import { erp_xuat_kho_indexComponent } from './erp-xuat-kho/index.component';
import { erp_loai_nhap_xuat_indexComponent } from './erp-loai-nhap_xuat/index.component';
import { erp_don_hang_ban_indexComponent } from './erp-don-hang-ban/index.component';
import { erp_don_hang_mua_indexComponent } from './erp-don-hang-mua/index.component';
import { erp_don_vi_van_chuyen_indexComponent } from './erp-don-vi-van-chuyen/index.component';

export const erproutes: Route[] = [
    {
        path: 'erp_nhap_kho_index',
        component: erp_nhap_kho_indexComponent,
    },
    {
        path: 'erp_nhap_kho_index',
        component: erp_nhap_kho_indexComponent,
    },
    {
        path: 'erp_don_hang_ban_index',
        component: erp_don_hang_ban_indexComponent,
    },
    {
        path: 'erp_don_hang_mua_index',
        component: erp_don_hang_mua_indexComponent,
    },
    {
        path: 'erp_loai_nhap_xuat_index',
        component: erp_loai_nhap_xuat_indexComponent,
    },
    {
        path: 'erp_don_vi_van_chuyen_index',
        component: erp_don_vi_van_chuyen_indexComponent,
    },
];
