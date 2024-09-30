export interface sys_lien_ket_model {
    db: sys_lien_ket_db;
    create_name: string;
    update_name: string;
}
export interface sys_lien_ket_db {
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
