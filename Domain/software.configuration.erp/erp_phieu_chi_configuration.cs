using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_phieu_chi_configuration : IEntityTypeConfiguration<erp_phieu_chi_db>
    {
        public void Configure(EntityTypeBuilder<erp_phieu_chi_db> builder)
        {
            builder.ToTable("erp_phieu_chi", "dbo");

            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();

            builder.Property(x => x.name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ly_do_chinh_sua).HasMaxLength(500);
            builder.Property(x => x.nguon).IsRequired();
            builder.Property(x => x.id_loai_chi).IsRequired();



            builder.Property(q => q.ngay_chi).IsRequired().HasDefaultValueSql("getutcdate()");

            builder.Property(q => q.phuong_thuc_thanh_toan).IsRequired().HasDefaultValueSql("1");
            builder.Property(q => q.id_doi_tuong).IsRequired();
            builder.Property(x => x.dia_chi_doi_tuong).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ten_doi_tuong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ma_so_thue).HasMaxLength(50);
            builder.Property(x => x.so_tai_khoan_doi_tuong).HasMaxLength(50);
            builder.Property(x => x.email).HasMaxLength(128);
            builder.Property(x => x.dien_thoai).HasMaxLength(50);

            builder.Property(x => x.so_tai_khoan).HasMaxLength(50);
            builder.Property(x => x.ma_ngan_hang).HasMaxLength(50);
            builder.Property(x => x.ten_ngan_hang).HasMaxLength(128);



            builder.Property(x => x.tai_khoan_co).HasMaxLength(50);
            builder.Property(x => x.tai_khoan_no).HasMaxLength(50);
            builder.Property(x => x.doi_tuong_co).HasMaxLength(50);
            builder.Property(x => x.doi_tuong_no).HasMaxLength(50);

            builder.Property(x => x.so_tien).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.so_phieu).HasMaxLength(128);

            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
