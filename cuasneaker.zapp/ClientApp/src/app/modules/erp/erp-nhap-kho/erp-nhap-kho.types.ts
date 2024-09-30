export interface erp_nhap_kho_db {
    id: number;
    code: string;
    loai_nhap: string;
    name: string;
    id_kho: string;
    ngay_nhap: string | null;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface erp_nhap_kho_model {
    db: erp_nhap_kho_db;
    list_detail: erp_nhap_kho_chi_tiet_model[];
    create_name: string;
    update_name: string;
}
export interface erp_nhap_kho_chi_tiet_db {
    id: number;
    id_phieu_nhap: number | null;
    id_san_pham: string;
    so_luong: number;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface erp_nhap_kho_chi_tiet_model {
    db: erp_nhap_kho_chi_tiet_db;
    create_name: string;
    update_name: string;
}
