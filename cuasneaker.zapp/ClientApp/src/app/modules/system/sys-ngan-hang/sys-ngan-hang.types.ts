export interface sys_ngan_hang_model {
    db: sys_ngan_hang_db;
    create_name: string;
    update_name: string;
}
export interface sys_ngan_hang_db {
    id: number;
    code: string;
    name: string;
    so_tai_khoan: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
