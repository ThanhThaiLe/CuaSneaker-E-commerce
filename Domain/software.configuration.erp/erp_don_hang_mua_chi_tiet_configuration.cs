using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_don_hang_mua_chi_tiet_configuration : IEntityTypeConfiguration<erp_don_hang_mua_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<erp_don_hang_mua_chi_tiet_db> builder)
        {
            builder.ToTable("erp_don_hang_mua_chi_tiet", "dbo");

            builder.Property(q => q.id_don_hang).IsRequired();
            builder.Property(q => q.id_mat_hang).IsRequired();
            builder.Property(q => q.ten_mat_hang).IsRequired();
            builder.Property(q => q.ma_mat_hang).IsRequired();
            builder.Property(q => q.id_nhan_hieu).IsRequired();
            builder.Property(q => q.id_don_vi_tinh).IsRequired();
            builder.Property(q => q.so_luong).IsRequired();

            builder.Property(x => x.don_gia).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_sau_chiet_khau).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_chiet_khau).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_truoc_chiet_khau).IsRequired().HasPrecision(18, 2);

            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
        }
    }
}
