using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_hoa_don_ban_hang_chi_tiet_configuration : IEntityTypeConfiguration<erp_hoa_don_ban_hang_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<erp_hoa_don_ban_hang_chi_tiet_db> builder)
        {
            builder.ToTable("erp_hoa_don_ban_hang_chi_tiet", "dbo");

            builder.Property(x => x.id_hoa_don_ban).IsRequired();
            builder.Property(x => x.id_don_hang_ban).IsRequired();
            builder.Property(x => x.loai_hoa_don).IsRequired();
            builder.Property(x => x.id_mat_hang).IsRequired();

            builder.Property(q => q.so_luong).IsRequired();
            builder.Property(x => x.don_gia).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_truoc_thue).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_thue).IsRequired().HasPrecision(18, 2);

            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
