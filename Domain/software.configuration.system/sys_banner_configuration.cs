using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_banner_configuration : IEntityTypeConfiguration<sys_banner_db>
    {
        public void Configure(EntityTypeBuilder<sys_banner_db> builder)
        {
            builder.ToTable("sys_banner", "dbo");

            builder.Property(x => x.id_type).IsRequired();
            builder.Property(x => x.image_web).IsRequired();
            builder.Property(x => x.image_mobi).IsRequired();
            builder.Property(x => x.link).HasMaxLength(500).IsRequired();


            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
