using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_quoc_gia_configuration : IEntityTypeConfiguration<sys_quoc_gia_db>
    {
        public void Configure(EntityTypeBuilder<sys_quoc_gia_db> builder)
        {
            builder.ToTable("sys_quoc_gia", "dbo");

            builder.Property(x => x.ten).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ten_khong_dau).HasMaxLength(128).IsRequired();


            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);

        }
    }
}
