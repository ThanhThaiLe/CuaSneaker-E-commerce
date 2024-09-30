export interface sys_loai_san_pham_model {
    db: sys_loai_san_pham_db;
    create_name: string;
    update_name: string;
}
export interface sys_loai_san_pham_db {
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
