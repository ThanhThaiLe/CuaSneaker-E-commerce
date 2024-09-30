import { Route } from '@angular/router';
import { sys_group_user_indexComponent } from './sys-group-user/index.component';
import { ContactsDetailsComponent } from './sys-khach-hang/details/details.component';
import { ContactsListComponent } from './sys-khach-hang/list/list.component';
import {
    ContactsResolver,
    ContactsContactResolver,
} from './sys-khach-hang/contacts.resolvers';
import { sys_loai_san_pham_indexComponent } from './sys-loai-san-pham/index.component';
import { sys_don_vi_tinh_indexComponent } from './sys-don-vi-tinh/index.component';
import { sys_nhan_hieu_indexComponent } from './sys-nhan-hieu/index.component';
import { sys_san_pham_indexComponent } from './sys-san-pham/index.component';
import { sys_banner_indexComponent } from './sys-banner/index.component';
import { sys_kho_indexComponent } from './sys-kho/index.component';
import { sys_quoc_gia_indexComponent } from './sys-quoc-gia/index.component';
import { sys_quan_huyen_indexComponent } from './sys-quan-huyen/index.component';
import { sys_tinh_thanh_indexComponent } from './sys-tinh-thanh/index.component';
import { sys_type_mail_indexComponent } from './sys-type-mail/index.component';
import { sys_template_mail_indexComponent } from './sys-template-mail/index.component';
import { sys_color_indexComponent } from './sys-color/index.component';
import { sys_size_indexComponent } from './sys-size/index.component';
import { sys_san_pham_chi_tiet_indexComponent } from './sys-san-pham-chi-tiet/index.component';
import { sys_dieu_khoan_indexComponent } from './sys-dieu-khoan/index.component';
import { sys_lien_ket_indexComponent } from './sys-lien-ket/index.component';
import { sys_thong_tin_website_indexComponent } from './sys-thong-tin-website/index.component';
import { sys_vat_indexComponent } from './sys-vat/index.component';
import { sys_ngan_hang_indexComponent } from './sys-ngan-hang/index.component';

export const systemroutes: Route[] = [
    {
        path: 'sys_color_index',
        component: sys_color_indexComponent,
    },
    {
        path: 'sys_vat_index',
        component: sys_vat_indexComponent,
    },
    {
        path: 'sys_ngan_hang_index',
        component: sys_ngan_hang_indexComponent,
    },
    {
        path: 'sys_thong_tin_website_index',
        component: sys_thong_tin_website_indexComponent,
    },
    {
        path: 'sys_lien_ket_index',
        component: sys_lien_ket_indexComponent,
    },
    {
        path: 'sys_dieu_khoan_index',
        component: sys_dieu_khoan_indexComponent,
    },
    {
        path: 'sys_size_index',
        component: sys_size_indexComponent,
    },
    {
        path: 'sys_type_mail_index',
        component: sys_type_mail_indexComponent,
    },
    {
        path: 'sys_template_mail_index',
        component: sys_template_mail_indexComponent,
    },
    {
        path: 'sys_tinh_thanh_index',
        component: sys_tinh_thanh_indexComponent,
    },
    {
        path: 'sys_quan_huyen_index',
        component: sys_quan_huyen_indexComponent,
    },
    {
        path: 'sys_banner_index',
        component: sys_banner_indexComponent,
    },
    {
        path: 'sys_kho_index',
        component: sys_kho_indexComponent,
    },
    {
        path: 'sys_san_pham_index',
        component: sys_san_pham_indexComponent,
    },
    {
        path: 'sys_san_pham_chi_tiet_index',
        component: sys_san_pham_chi_tiet_indexComponent,
    },
    {
        path: 'sys_nhan_hieu_index',
        component: sys_nhan_hieu_indexComponent,
    },
    {
        path: 'sys_don_vi_tinh_index',
        component: sys_don_vi_tinh_indexComponent,
    },
    {
        path: 'sys_quoc_gia_index',
        component: sys_quoc_gia_indexComponent,
    },
    {
        path: 'sys_loai_san_pham_index',
        component: sys_loai_san_pham_indexComponent,
    },
    {
        path: 'sys_group_user_index',
        component: sys_group_user_indexComponent,
    },
    {
        path: 'sys_user_index',
        component: ContactsListComponent,
        resolve: {
            tasks: ContactsResolver,
        },
        children: [
            {
                path: ':id',
                component: ContactsDetailsComponent,
                resolve: {
                    task: ContactsContactResolver,
                },
            },
        ],
    },
    {
        path: 'sys_group_user_index',
        component: sys_group_user_indexComponent,
    },
];
