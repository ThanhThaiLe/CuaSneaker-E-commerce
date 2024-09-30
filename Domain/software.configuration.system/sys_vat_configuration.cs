using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_vat_configuration : IEntityTypeConfiguration<sys_vat_db>
    {
        public void Configure(EntityTypeBuilder<sys_vat_db> builder)
        {
            builder.ToTable("sys_vat", "dbo");

            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");

            builder.Property(x => x.value).IsRequired();
            builder.Property(x => x.code).HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.code)
                .IsUnique();
            builder.Property(x => x.name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.note).HasMaxLength(500).IsRequired();

            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
