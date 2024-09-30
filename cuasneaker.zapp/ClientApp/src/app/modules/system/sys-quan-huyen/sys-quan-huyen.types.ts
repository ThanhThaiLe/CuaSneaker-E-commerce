export interface sys_quan_huyen_db {
    id: number;
    id_quoc_gia: number | null;
    id_tinh: number | null;
    ten: string;
    ten_khong_dau: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
export interface sys_quan_huyen_model {
    db: sys_quan_huyen_db;
    tinh_thanh: string;
    quoc_gia: string;
    create_name: string;
    update_name: string;
}
