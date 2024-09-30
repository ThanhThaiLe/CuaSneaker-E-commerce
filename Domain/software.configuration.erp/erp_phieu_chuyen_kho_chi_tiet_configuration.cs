using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_phieu_chuyen_kho_chi_tiet_configuration : IEntityTypeConfiguration<erp_phieu_chuyen_kho_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<erp_phieu_chuyen_kho_chi_tiet_db> builder)
        {
            builder.ToTable("erp_phieu_chuyen_kho_chi_tiet", "dbo");

            builder.Property(x => x.id_phieu_xuat_kho).IsRequired();
            builder.Property(x => x.id_mat_hang).IsRequired();
            builder.Property(x => x.id_loai_mat_hang).IsRequired();
            builder.Property(x => x.id_don_vi_tinh).IsRequired();
            builder.Property(x => x.so_luong).IsRequired();
            builder.Property(x => x.ma_vach).HasMaxLength(128).IsRequired();

            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
