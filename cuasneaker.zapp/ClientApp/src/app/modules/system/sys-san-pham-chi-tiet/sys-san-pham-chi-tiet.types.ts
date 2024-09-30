import { sys_file_upload_model } from 'app/modules/portal/portal.types';

export interface sys_san_pham_chi_tiet_model {
    list_file: sys_file_upload_model[];
    db: sys_san_pham_chi_tiet_db;
    ma_san_pham: string;
    ten_san_pham: string;
    size: string;
    list_code_size: string[];
    list_id_size: number[];
    color: string;
    color_code: string;
    create_name: string;
    update_name: string;
}
export interface sys_san_pham_chi_tiet_db {
    id: number;
    id_san_pham: string;
    id_size: number | null;
    id_color: number | null;
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
