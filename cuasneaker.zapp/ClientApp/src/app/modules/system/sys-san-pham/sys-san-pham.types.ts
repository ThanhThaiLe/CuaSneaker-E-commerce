import { sys_file_upload_model } from 'app/modules/portal/portal.types';
import { sys_san_pham_chi_tiet_model } from '../sys-san-pham-chi-tiet/sys-san-pham-chi-tiet.types';

export interface sys_san_pham_model {
    db: sys_san_pham_db;
    list_file: sys_file_upload_model[];
    list_detail: sys_san_pham_chi_tiet_model[];
    ten_nhan_hieu: string;
    ten_loai_san_pham: string;
    ten_don_vi_tinh: string;
    create_name: string;
    update_name: string;
}
export interface sys_san_pham_db {
    id: string;
    id_loai_san_pham: number | null;
    id_nhan_hieu: number | null;
    id_don_vi_tinh: number | null;
    ten_san_pham: string;
    ma_san_pham: string;
    hinh_anh: string;
    mo_ta: string;
    gia_ban: number | null;
    gia_khuyen_mai: number | null;
    is_noi_bac: boolean | null;
    is_khuyen_mai: boolean | null;
    qr_image: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
    note: string;
}
