export interface erp_loai_nhap_xuat_model {
    db: erp_loai_nhap_xuat_db;
    create_name: string;
    update_name: string;
}
export interface erp_loai_nhap_xuat_db {
    id: number;
    code: string;
    name: string;
    loai_nhap_xuat: string;
    nguon: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
