export interface sys_don_vi_tinh_model {
    db: sys_don_vi_tinh_db;
    create_name: string;
    update_name: string;
}
export interface sys_don_vi_tinh_db {
    id: number;
    code: string;
    name: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
