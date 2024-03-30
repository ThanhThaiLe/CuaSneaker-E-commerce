export interface erp_don_hang_mua_model {
    db: erp_don_hang_mua_db;
    list_detail: erp_don_hang_mua_chi_tiet_model[];
    create_name: string;
    update_name: string;
}
export interface erp_don_hang_mua_chi_tiet_model {
    db: erp_don_hang_mua_chi_tiet_db;
    create_name: string;
    update_name: string;
}
export interface erp_don_hang_mua_db {
    id: number;
    code: string;
    name: string;
    loai_don_hang: number | null;
    note: string;
    ngay_dat_hang: string | null;
    phuong_thuc_thanh_toan: number | null;
    thanh_tien_truoc_thue: number | null;
    thanh_tien_sau_thue: number | null;
    tien_thue: number | null;
    ty_le_vat: number | null;
    id_ty_le_vat: number | null;
    trang_thai_thanh_toan: boolean | null;
    trang_thai_xuat_hang: boolean | null;
    so_ngay_du_kien_giao: number | null;
    ngay_du_kien_giao: string | null;
    thanh_tien_van_chuyen_truoc_thue: number | null;
    thanh_tien_van_chuyen_sau_thue: number | null;
    tien_thue_van_chuyen: number | null;
    ty_le_vat_van_chuyen: number | null;
    id_ty_le_vat_van_chuyen: number | null;
    id_tinh_khach_hang_nhan: number | null;
    id_quan_khach_hang_nhan: number | null;
    dia_chi_cu_the_khach_hang_nhan: string;
    full_name_khach_hang_nhan: string;
    first_name_khach_hang_nhan: string;
    last_name_khach_hang_nhan: string;
    email_khach_hang_nhan: string;
    phone_khach_hang_nhan: string;
    id_quan_khach_hang_dat: number | null;
    id_tinh_khach_hang_dat: number | null;
    dia_chi_cu_the_khach_hang_dat: string;
    full_name_khach_hang_dat: string;
    first_name_khach_hang_dat: string;
    last_name_khach_hang_dat: string;
    email_khach_hang_dat: string;
    phone_khach_hang_dat: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface erp_don_hang_mua_chi_tiet_db {
    id: number;
    id_don_hang: number | null;
    id_san_pham: number;
    so_luong: number;
    don_gia: number | null;
    thanh_tien: number | null;
    chiet_khau: number | null;
    id_chiet_khau: number | null;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
