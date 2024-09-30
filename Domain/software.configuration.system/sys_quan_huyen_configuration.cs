using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_quan_huyen_configuration : IEntityTypeConfiguration<sys_quan_huyen_db>
    {
        public void Configure(EntityTypeBuilder<sys_quan_huyen_db> builder)
        {
            builder.ToTable("sys_quan_huyen", "dbo");

            builder.Property(q => q.id_quoc_gia).IsRequired();
            builder.Property(q => q.id_tinh).IsRequired();

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
