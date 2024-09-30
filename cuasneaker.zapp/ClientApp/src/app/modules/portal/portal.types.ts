import { FuseNavigationItem } from '@fuse/components/navigation';
import { sys_common_number_model } from '../common-model/sys-common-model.types';
import { User } from 'app/core/user/user.model';
import { sys_thong_tin_website_db } from '../system/sys-thong-tin-website/sys-thong-tin-website.types';
export interface portal_home_model {}
export interface sys_user_nhan_hang_db {
    id: string;
    id_tinh: number | null;
    id_quan: number | null;
    dia_chi_cu_the: string;
    id_user: string;
    full_name: string;
    first_name: string;
    last_name: string;
    email: string;
    phone: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface portal_payment_model {
    email: string;
    firstName: string;
    lastName: string;
    so_dien_thoai: string;
    about: string;
    tinh_thanh: string;
    quan_huyen: string;
    dia_chi: string;
    list_san_pham_detail: portal_san_pham_chi_tiet_model[];
}
export interface portal_san_pham_model {
    id: string;
    ten_san_pham: string;
    ma_san_pham: string;
    loai_san_pham: string;
    nhan_hieu: string;
    mo_ta: string;
    hinh_anh: string;
    id_loai_san_pham: number | null;
    is_khuyen_mai: boolean | null;
    is_noi_bac: boolean | null;
    gia_ban: number | null;
    gia_khuyen_mai: number | null;
    list_san_pham_detail: portal_san_pham_chi_tiet_model[];
    list_size: sys_common_number_model[];
    list_color: sys_common_number_model[];
}
export interface portal_san_pham_chi_tiet_model {
    id: number | null;
    link: string;
    id_san_pham: string;
    id_size: string;
    id_color: number | null;
    gia_ban: number | null;
    ma_san_pham: string;
    mo_ta: string;
    ten_san_pham: string;
    size: string;
    size_code: string;
    color: string;
    color_code: string;
    list_file: sys_file_upload_model[];
    list_size: sys_common_number_model[];
}

export interface portal_san_pham_chi_tiet_card_model {
    id: number | null;
    id_san_pham: string;
    id_size: number | null;
    id_color: number | null;
    link: string;
    so_luong: number | null;
    gia_ban: number | null;
    ma_san_pham: string;
    ten_san_pham: string;
    size: string;
    size_code: string;
    color: string;
    color_code: string;
}
export interface sys_file_upload_model {
    db: sys_file_upload_db;
    create_name: string;
    update_name: string;
}
export interface sys_file_upload_db {
    id: number;
    controller: string;
    id_parent: string;
    file_type: string;
    file_name: string;
    file_size: number;
    file_path: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface InitialDataPortal {
    products: portal_san_pham_model[];
    type_products: sys_common_number_model[];
    list_lien_ket: sys_common_number_model[];
    list_dieu_khoan: sys_common_number_model[];
    list_nhan_hieu: sys_common_number_model[];
    thong_tin_website: sys_thong_tin_website_db;
    banners: portal_banner_model[];
    navigation: {
        compact: FuseNavigationItem[];
        default: FuseNavigationItem[];
        futuristic: FuseNavigationItem[];
        horizontal: FuseNavigationItem[];
    };
    user: User;
}
export interface portal_banner_model {
    id: number;
    id_type: string;
    image_web: string;
    image_mobi: string;
    link: string;
}
