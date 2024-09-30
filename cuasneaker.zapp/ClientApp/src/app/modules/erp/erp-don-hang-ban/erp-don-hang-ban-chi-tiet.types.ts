export interface erp_don_hang_ban_chi_tiet_db {
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
    create_date: Date | null;
    update_by: string;
    update_date: Date | null;
    status_del: number | null;
}
export interface erp_don_hang_ban_chi_tiet_model {
    db: erp_don_hang_ban_chi_tiet_db;
    create_name: string;
    update_name: string;
}
