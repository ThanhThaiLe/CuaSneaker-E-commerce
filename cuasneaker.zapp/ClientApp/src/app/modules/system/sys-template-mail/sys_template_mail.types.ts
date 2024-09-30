export interface sys_template_mail_db {
    id: string;
    id_type: string;
    name: string;
    template: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface sys_template_mail_model {
    db: sys_template_mail_db;
    type_name_mail: string;
    create_name: string;
    update_name: string;
}
