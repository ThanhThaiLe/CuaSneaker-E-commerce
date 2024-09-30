using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_xuat_kho_configuration : IEntityTypeConfiguration<erp_xuat_kho_db>
    {
        public void Configure(EntityTypeBuilder<erp_xuat_kho_db> builder)
        {
            builder.ToTable("erp_xuat_kho", "dbo");

            builder.Property(x => x.name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();

            builder.Property(x => x.so_phieu).IsRequired().HasMaxLength(128);
            builder.HasIndex(x => x.so_phieu).IsUnique();

            builder.Property(x => x.hinh_thuc_doi_tuong).HasDefaultValueSql("1");
            builder.Property(x => x.id_doi_tuong).IsRequired().HasMaxLength(128);
            builder.Property(x => x.ten_doi_tuong).IsRequired().HasMaxLength(128);
            builder.Property(x => x.ma_so_thue).HasMaxLength(50);
            builder.Property(x => x.dien_thoai).HasMaxLength(50);
            builder.Property(x => x.email).HasMaxLength(128);
            builder.Property(x => x.dia_chi).HasMaxLength(500);

            builder.Property(x => x.ngay_xuat).HasDefaultValueSql("getutcdate()");

            builder.Property(x => x.is_sinh_tu_dong).HasDefaultValueSql("0");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
