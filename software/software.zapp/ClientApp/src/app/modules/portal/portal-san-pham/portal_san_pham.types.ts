export interface portal_home_model {}

export interface portal_san_pham_model {
    id: string;
    link: string;
    ten_san_pham: string;
    ma_san_pham: string;
    loai_san_pham: string;
    mo_ta: string;
    hinh_anh: string;
    id_loai_san_pham: number | null;
    is_khuyen_mai: boolean | null;
    is_noi_bac: boolean | null;
    gia_ban: number | null;
    gia_khuyen_mai: number | null;
}
