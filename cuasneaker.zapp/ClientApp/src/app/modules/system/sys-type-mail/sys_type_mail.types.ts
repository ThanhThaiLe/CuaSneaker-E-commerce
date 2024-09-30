export interface sys_type_mail_db {
    id: string;
    code: string;
    name: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface sys_type_mail_model {
    db: sys_type_mail_db;
    create_name: string;
    update_name: string;
}
