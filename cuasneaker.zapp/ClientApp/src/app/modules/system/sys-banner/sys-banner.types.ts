export interface sys_banner_model {
    db: sys_banner_db;
    create_name: string;
    update_name: string;
}
export interface sys_banner_db {
    id: number;
    id_type: string;
    image_web: string;
    image_mobi: string;
    link: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
