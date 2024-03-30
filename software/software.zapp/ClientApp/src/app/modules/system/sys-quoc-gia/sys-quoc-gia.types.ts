export interface sys_quoc_gia_db {
    id: number;
    ten: string;
    ten_khong_dau: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface sys_quoc_gia_model {
    db: sys_quoc_gia_db;
    create_name: string;
    update_name: string;
}
