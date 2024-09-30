using Microsoft.EntityFrameworkCore;
using software.configuration.system;
using software.entity.system;

namespace software.database.Provider
{
    public partial class SoftwareDefautTable
    {
        public virtual DbSet<sys_nha_cung_cap_db> sys_nha_cung_caps { get; set; }
        public virtual DbSet<sys_tai_san_db> sys_tai_sans { get; set; }
        public virtual DbSet<sys_tai_san_lich_su_cap_nhat_db> sys_tai_san_lich_su_cap_nhats { get; set; }
        public virtual DbSet<sys_sticker_db> sys_stickers { get; set; }
        public virtual DbSet<sys_sticker_detail_db> sys_sticker_details { get; set; }
        public virtual DbSet<sys_ngan_hang_db> sys_ngan_hangs { get; set; }
        public virtual DbSet<sys_vat_db> sys_vats { get; set; }
        public virtual DbSet<sys_user_nhan_hang_db> sys_user_nhan_hangs { get; set; }
        public virtual DbSet<sys_file_upload_db> sys_file_uploads { get; set; }
        public virtual DbSet<sys_san_pham_chi_tiet_db> sys_san_pham_chi_tiets { get; set; }
        public virtual DbSet<sys_color_db> sys_colors { get; set; }
        public virtual DbSet<sys_size_db> sys_sizes { get; set; }
        public virtual DbSet<sys_kho_db> sys_khos { get; set; }
        public virtual DbSet<sys_banner_db> sys_banners { get; set; }
        public virtual DbSet<sys_loai_san_pham_db> sys_loai_san_phams { get; set; }
        public virtual DbSet<sys_nhan_hieu_db> sys_nhan_hieus { get; set; }
        public virtual DbSet<sys_tinh_thanh_db> sys_tinh_thanhs { get; set; }
        public virtual DbSet<sys_quan_huyen_db> sys_quan_huyens { get; set; }
        public virtual DbSet<sys_template_mail_db> sys_template_mails { get; set; }
        public virtual DbSet<sys_type_mail_db> sys_type_mails { get; set; }
        public virtual DbSet<sys_quoc_gia_db> sys_quoc_gias { get; set; }
        public virtual DbSet<sys_thong_tin_website_db> sys_thong_tin_websites { get; set; }
        public virtual DbSet<sys_don_vi_tinh_db> sys_don_vi_tinhs { get; set; }
        public virtual DbSet<sys_lien_ket_db> sys_lien_kets { get; set; }
        public virtual DbSet<sys_dieu_khoan_db> sys_dieu_khoans { get; set; }
        public virtual DbSet<sys_san_pham_db> sys_san_phams { get; set; }
        public virtual DbSet<sys_group_user_db> sys_group_users { get; set; }
        public virtual DbSet<sys_group_user_detail_db> sys_group_user_details { get; set; }
        public virtual DbSet<sys_group_user_role_db> sys_group_user_rolers { get; set; }
        public virtual DbSet<sys_user_db> sys_users { get; set; }
        protected void systemTableBuilder(ModelBuilder model)
        {
            OnModelCreatingPartial(model);
            model.ApplyConfiguration(new sys_sticker_detail_configuration());
            model.ApplyConfiguration(new sys_sticker_configuration());
            model.ApplyConfiguration(new sys_nha_cung_cap_configuration());
            model.ApplyConfiguration(new sys_tai_san_lich_su_cap_nhat_configuration());
            model.ApplyConfiguration(new sys_tai_san_configuration());
            model.ApplyConfiguration(new sys_ngan_hang_configuration());
            model.ApplyConfiguration(new sys_vat_configuration());
            model.ApplyConfiguration(new sys_user_nhan_hang_configuration());
            model.ApplyConfiguration(new sys_file_upload_configuration());
            model.ApplyConfiguration(new sys_san_pham_chi_tiet_configuration());
            model.ApplyConfiguration(new sys_color_configuration());
            model.ApplyConfiguration(new sys_size_configuration());
            model.ApplyConfiguration(new sys_kho_configuration());
            model.ApplyConfiguration(new sys_banner_configuration());
            model.ApplyConfiguration(new sys_loai_san_pham_configuration());
            model.ApplyConfiguration(new sys_nhan_hieu_configuration());
            model.ApplyConfiguration(new sys_tinh_thanh_configuration());
            model.ApplyConfiguration(new sys_quan_huyen_configuration());
            model.ApplyConfiguration(new sys_template_mail_configuration());
            model.ApplyConfiguration(new sys_type_mail_configuration());
            model.ApplyConfiguration(new sys_quoc_gia_configuration());
            model.ApplyConfiguration(new sys_thong_tin_website_configuration());
            model.ApplyConfiguration(new sys_don_vi_tinh_configuration());
            model.ApplyConfiguration(new sys_lien_ket_configuration());
            model.ApplyConfiguration(new sys_dieu_khoan_configuration());
            model.ApplyConfiguration(new sys_san_pham_configuration());
            model.ApplyConfiguration(new sys_group_user_configuration());
            model.ApplyConfiguration(new sys_group_user_detail_configuration());
            model.ApplyConfiguration(new sys_group_user_role_configuration());
            model.ApplyConfiguration(new sys_user_configuration());
        }
    }
}
