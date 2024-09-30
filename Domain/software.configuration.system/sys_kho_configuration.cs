using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_kho_configuration : IEntityTypeConfiguration<sys_kho_db>
    {
        public void Configure(EntityTypeBuilder<sys_kho_db> builder)
        {
            builder.ToTable("sys_kho", "dbo");

            builder.Property(x => x.name).HasMaxLength(128);
            builder.Property(x => x.address).HasMaxLength(500);
            builder.Property(x => x.code).HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();



            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);

        }
    }
}
