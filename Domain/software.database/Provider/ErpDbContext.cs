using Microsoft.EntityFrameworkCore;
using software.configuration.erp;
using software.entity.erp;
namespace software.database.Provider
{
    public partial class SoftwareDefautTable
    {
        public virtual DbSet<erp_phieu_chi_chi_tiet_db> erp_phieu_chi_chi_tiets { get; set; }
        public virtual DbSet<erp_phieu_chi_db> erp_phieu_chis { get; set; }
        public virtual DbSet<erp_phieu_chuyen_kho_chi_tiet_db> erp_phieu_chuyen_kho_chi_tiets { get; set; }
        public virtual DbSet<erp_phieu_chuyen_kho_db> erp_phieu_chuyen_khos { get; set; }
        public virtual DbSet<erp_phieu_thu_chi_tiet_db> erp_phieu_thu_chi_tiets { get; set; }
        public virtual DbSet<erp_phieu_thu_db> erp_phieu_thus { get; set; }
        public virtual DbSet<erp_mat_hang_db> erp_mat_hangs { get; set; }
        public virtual DbSet<erp_hoa_don_ban_hang_db> erp_hoa_don_ban_hangs { get; set; }
        public virtual DbSet<erp_hoa_don_ban_hang_chi_tiet_db> erp_hoa_don_ban_hang_chi_tiets { get; set; }
        public virtual DbSet<erp_don_vi_van_chuyen_db> erp_don_vi_van_chuyens { get; set; }
        public virtual DbSet<erp_loai_nhap_xuat_db> erp_loai_nhap_xuats { get; set; }
        public virtual DbSet<erp_xuat_kho_chi_tiet_db> erp_xuat_kho_chi_tiets { get; set; }
        public virtual DbSet<erp_xuat_kho_db> erp_xuat_khos { get; set; }
        public virtual DbSet<erp_don_hang_ban_chi_tiet_db> erp_don_hang_ban_chi_tiets { get; set; }
        public virtual DbSet<erp_don_hang_ban_db> erp_don_hang_bans { get; set; }
        public virtual DbSet<erp_don_hang_mua_chi_tiet_db> erp_don_hang_mua_chi_tiets { get; set; }
        public virtual DbSet<erp_don_hang_mua_db> erp_don_hang_muas { get; set; }
        public virtual DbSet<erp_nhap_kho_chi_tiet_db> erp_nhap_kho_chi_tiets { get; set; }
        public virtual DbSet<erp_nhap_kho_db> erp_nhap_khos { get; set; }
        public virtual DbSet<erp_loai_thu_chi_db> erp_loai_thu_chis { get; set; }
        protected void erpTableBuilder(ModelBuilder model)
        {
            OnModelCreatingPartial(model);
            model.ApplyConfiguration(new erp_phieu_thu_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_phieu_thu_configuration());
            model.ApplyConfiguration(new erp_phieu_chuyen_kho_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_phieu_chuyen_kho_configuration());
            model.ApplyConfiguration(new erp_phieu_chi_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_phieu_chi_configuration());
            model.ApplyConfiguration(new erp_mat_hang_configuration());
            model.ApplyConfiguration(new erp_hoa_don_ban_hang_configuration());
            model.ApplyConfiguration(new erp_hoa_don_ban_hang_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_don_vi_van_chuyen_configuration());
            model.ApplyConfiguration(new erp_loai_nhap_xuat_configuration());
            model.ApplyConfiguration(new erp_xuat_kho_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_xuat_kho_configuration());
            model.ApplyConfiguration(new erp_don_hang_ban_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_don_hang_ban_configuration());
            model.ApplyConfiguration(new erp_don_hang_mua_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_don_hang_mua_configuration());
            model.ApplyConfiguration(new erp_nhap_kho_chi_tiet_configuration());
            model.ApplyConfiguration(new erp_nhap_kho_configuration());
            model.ApplyConfiguration(new erp_loai_thu_chi_configuration());
        }
    }
}
