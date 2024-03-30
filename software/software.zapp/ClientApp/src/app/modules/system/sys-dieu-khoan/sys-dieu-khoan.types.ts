export interface sys_dieu_khoan_model {
    db: sys_dieu_khoan_db;
    create_name: string;
    update_name: string;
}
export interface sys_dieu_khoan_db {
    id: number;
    code: string;
    name: string;
    note: string;
    link: string;
    stt: number | null;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
