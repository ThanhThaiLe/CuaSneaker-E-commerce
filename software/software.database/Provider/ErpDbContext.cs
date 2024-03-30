using Microsoft.EntityFrameworkCore;
using software.database.System;

namespace software.database.Provider
{
    public partial class SoftwareDefautTable
    {
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
        protected void erpTableBuilder(ModelBuilder model)
        {
            OnModelCreatingPartial(model);
        }
    }
}
