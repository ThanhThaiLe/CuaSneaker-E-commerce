using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_phieu_thu_chi_tiet_configuration : IEntityTypeConfiguration<erp_phieu_thu_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<erp_phieu_thu_chi_tiet_db> builder)
        {
            builder.ToTable("erp_phieu_thu_chi_tiet", "dbo");



            builder.Property(x => x.id_phieu_thu).IsRequired();
            builder.Property(x => x.noi_dung).IsRequired().HasMaxLength(500);


            builder.Property(x => x.tai_khoan_co).HasMaxLength(50);
            builder.Property(x => x.tai_khoan_no).HasMaxLength(50);
            builder.Property(x => x.doi_tuong_co).HasMaxLength(50);
            builder.Property(x => x.doi_tuong_no).HasMaxLength(50);

            builder.Property(x => x.is_dinh_khoan).HasDefaultValueSql("0");

            builder.Property(x => x.so_tien).IsRequired().HasPrecision(18, 2);

            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
