using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_type_mail_configuration : IEntityTypeConfiguration<sys_type_mail_db>
    {
        public void Configure(EntityTypeBuilder<sys_type_mail_db> builder)
        {
            builder.ToTable("sys_type_mail", "dbo");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");

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
