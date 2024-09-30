export interface sys_nhan_hieu_model {
    db: sys_nhan_hieu_db;
    create_name: string;
    update_name: string;
}
export interface sys_nhan_hieu_db {
    id: number;
    name: string;
    code: string;
    image: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
