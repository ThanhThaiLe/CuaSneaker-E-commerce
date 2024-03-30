export interface erp_don_hang_ban_chi_tiet_db {
    id: number;
    id_don_hang: number | null;
    id_san_pham: string;
    id_size: string;
    id_color: number;
    don_gia: number | null;
    so_luong: number | null;
    thanh_tien_thue: number | null;
    thanh_tien_chiet_khau: number | null;
    thanh_tien_truoc_thue: number | null;
    thanh_tien_sau_thue: number | null;
    gia_tri_chiet_khau: number | null;
    gia_tri_vat: number | null;
    id_vat: number | null;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface erp_don_hang_ban_chi_tiet_model {
    db: erp_don_hang_ban_chi_tiet_db;
    create_name: string;
    update_name: string;
    ma_san_pham: string;
    ten_san_pham: string;
    ten_nhan_hieu: string;
    ten_loai_san_pham: string;
    color_code: string;
    color: string;
    size: string;
    size_code: string;
    gia_ban: string;
    ten_don_vi_tinh: string;
    gia_tri_vat: number | null;
}
