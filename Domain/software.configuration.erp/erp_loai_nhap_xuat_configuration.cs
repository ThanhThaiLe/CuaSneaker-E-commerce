using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_loai_nhap_xuat_configuration : IEntityTypeConfiguration<erp_loai_nhap_xuat_db>
    {
        public void Configure(EntityTypeBuilder<erp_loai_nhap_xuat_db> builder)
        {
            builder.ToTable("erp_loai_nhap_xuat", "dbo");

            builder.Property(x => x.name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();
            builder.Property(x => x.loai_nhap_xuat).IsRequired();
            builder.Property(x => x.nguon).IsRequired();



            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
