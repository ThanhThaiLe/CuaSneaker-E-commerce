using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_tai_san_lich_su_cap_nhat_configuration : IEntityTypeConfiguration<sys_tai_san_lich_su_cap_nhat_db>
    {
        public void Configure(EntityTypeBuilder<sys_tai_san_lich_su_cap_nhat_db> builder)
        {
            builder.ToTable("sys_tai_san_lich_su_cap_nhat", "dbo");

            builder.Property(x => x.code).HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.code)
                .IsUnique();
            builder.Property(x => x.name).HasMaxLength(50).IsRequired();

            builder.Property(q => q.id_tai_san).IsRequired();
            builder.Property(q => q.loai).IsRequired();
            builder.Property(q => q.so_luong).IsRequired();

            builder.Property(x => x.dia_diem_ban_giao).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ly_do).HasMaxLength(500).IsRequired();
            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
