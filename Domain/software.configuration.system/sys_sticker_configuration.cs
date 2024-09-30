using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_sticker_configuration : IEntityTypeConfiguration<sys_sticker_db>
    {
        public void Configure(EntityTypeBuilder<sys_sticker_db> builder)
        {
            builder.ToTable("sys_sticker", "dbo");
            builder.Property(x => x.code).HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.code)
                .IsUnique();

            builder.Property(x => x.name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.loai).IsRequired();
            builder.Property(x => x.avatar).HasMaxLength(500).IsRequired();

            builder.Property(x => x.stt).HasDefaultValueSql("0");

            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
