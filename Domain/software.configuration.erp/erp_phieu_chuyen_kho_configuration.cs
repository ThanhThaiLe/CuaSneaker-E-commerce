using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_phieu_chuyen_kho_configuration : IEntityTypeConfiguration<erp_phieu_chuyen_kho_db>
    {
        public void Configure(EntityTypeBuilder<erp_phieu_chuyen_kho_db> builder)
        {
            builder.ToTable("erp_phieu_chuyen_kho", "dbo");



            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();

            builder.Property(x => x.name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ly_do_chinh_sua).HasMaxLength(500);
            builder.Property(x => x.nguon).HasDefaultValueSql("1");
            builder.Property(x => x.id_loai_nhap).IsRequired();
            builder.Property(x => x.id_loai_xuat).IsRequired();

            builder.Property(x => x.ngay_du_kien_chuyen_di).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.ngay_du_kien_nhap_ve).HasDefaultValueSql("getutcdate()");

            builder.Property(x => x.id_kho_nhap).IsRequired();
            builder.Property(x => x.id_kho_xuat).IsRequired();

            builder.Property(x => x.hinh_thuc_doi_tuong).HasDefaultValueSql("1");
            builder.Property(q => q.id_doi_tuong).IsRequired();
            builder.Property(x => x.dia_chi_doi_tuong).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ten_doi_tuong).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ma_so_thue).HasMaxLength(50);
            builder.Property(x => x.email).HasMaxLength(128);
            builder.Property(x => x.dien_thoai).HasMaxLength(50);



            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
