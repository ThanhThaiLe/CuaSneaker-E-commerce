using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_san_pham_chi_tiet_configuration : IEntityTypeConfiguration<sys_san_pham_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<sys_san_pham_chi_tiet_db> builder)
        {
            builder.ToTable("sys_san_pham_chi_tiet", "dbo");



            builder.Property(x => x.id_san_pham).IsRequired();
            builder.Property(x => x.id_size).IsRequired();
            builder.Property(x => x.id_color).IsRequired();
            builder.Property(x => x.hinh_anh).IsRequired();
            builder.Property(x => x.mo_ta).IsRequired();
            builder.Property(x => x.gia_ban).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.is_noi_bac).HasDefaultValueSql("0");
            builder.Property(x => x.is_khuyen_mai).HasDefaultValueSql("0");


            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
