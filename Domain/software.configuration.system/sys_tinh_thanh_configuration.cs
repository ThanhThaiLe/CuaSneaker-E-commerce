using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_tinh_thanh_configuration : IEntityTypeConfiguration<sys_tinh_thanh_db>
    {
        public void Configure(EntityTypeBuilder<sys_tinh_thanh_db> builder)
        {
            builder.ToTable("sys_tinh_thanh", "dbo");


            builder.HasIndex(q => q.id_quoc_gia).IsUnique();

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
