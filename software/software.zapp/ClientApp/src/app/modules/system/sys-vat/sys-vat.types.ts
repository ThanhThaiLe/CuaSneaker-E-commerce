export interface sys_vat_model {
    db: sys_vat_db;
    create_name: string;
    update_name: string;
}
export interface sys_vat_db {
    id: number;
    code: string;
    name: string;
    value: number | null;
    note: string;
    create_by: string;
    create_date: Date | null;
    update_by: string;
    update_date: Date | null;
    status_del: number | null;
}
