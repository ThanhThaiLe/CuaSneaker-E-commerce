using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_mat_hang_configuration : IEntityTypeConfiguration<erp_mat_hang_db>
    {
        public void Configure(EntityTypeBuilder<erp_mat_hang_db> builder)
        {
            builder.ToTable("erp_mat_hang", "dbo");

            builder.Property(x => x.name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();
            builder.Property(x => x.xuat_xu).IsRequired().HasMaxLength(128);
            builder.Property(x => x.tien_te).IsRequired().HasMaxLength(10);
            builder.Property(x => x.don_vi_tinh_quy_doi).IsRequired().HasMaxLength(128);
            builder.Property(x => x.id_loai_san_pham).IsRequired();
            builder.Property(x => x.id_don_vi_tinh).IsRequired();

            builder.Property(x => x.gia_ban_le).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.gia_ban_si).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.gia_von).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.he_so_quy_doi).IsRequired().HasPrecision(18, 2);


            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
