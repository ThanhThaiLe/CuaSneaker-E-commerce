export interface sys_tinh_thanh_db {
    id: number;
    id_quoc_gia: number | null;
    ten: string;
    ten_khong_dau: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface sys_tinh_thanh_model {
    db: sys_tinh_thanh_db;
    quoc_gia: string;
    create_name: string;
    update_name: string;
}
