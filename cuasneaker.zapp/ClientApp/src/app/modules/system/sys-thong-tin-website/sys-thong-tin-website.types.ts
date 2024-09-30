export interface sys_thong_tin_website_model {
    db: sys_thong_tin_website_db;
    create_name: string;
    update_name: string;
}
export interface sys_thong_tin_website_db {
    id: number;
    image_logo: string;
    image_footer: string;
    dia_chi: string;
    so_dien_thoai: string;
    email: string;
    link_facebook: string;
    link_youtube: string;
    link_linkedin: string;
    link_instagram: string;
    image_facebook: string;
    image_youtube: string;
    image_linkedin: string;
    image_instagram: string;
    note: string;
    create_by: string;
    create_date: string | null;
    update_by: string;
    update_date: string | null;
    status_del: number | null;
}
