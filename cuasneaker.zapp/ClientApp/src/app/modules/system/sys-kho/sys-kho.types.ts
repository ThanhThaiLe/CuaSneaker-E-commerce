export interface sys_kho_model {
    db: sys_kho_db;
    create_name: string;
    update_name: string;
}
export interface sys_kho_db {
    id: number;
    code: string;
    name: string;
    address: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
