using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_don_vi_van_chuyen_configuration : IEntityTypeConfiguration<erp_don_vi_van_chuyen_db>
    {
        public void Configure(EntityTypeBuilder<erp_don_vi_van_chuyen_db> builder)
        {
            builder.ToTable("erp_don_vi_van_chuyen", "dbo");

            builder.Property(x => x.code).HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.code)
                .IsUnique();
            builder.Property(x => x.name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
        }
    }
}
