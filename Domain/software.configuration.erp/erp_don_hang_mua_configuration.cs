using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_don_hang_mua_configuration : IEntityTypeConfiguration<erp_don_hang_mua_db>
    {
        public void Configure(EntityTypeBuilder<erp_don_hang_mua_db> builder)
        {
            builder.ToTable("erp_don_hang_mua", "dbo");

            builder.Property(x => x.code).IsRequired().HasMaxLength(10);
            builder.HasIndex(x => x.code).IsUnique();

            builder.Property(x => x.name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(500);

            builder.Property(q => q.loai_don_hang).IsRequired();

            builder.Property(q => q.ngay_dat_hang).IsRequired().HasDefaultValueSql("getutcdate()");

            builder.Property(q => q.phuong_thuc_thanh_toan).IsRequired().HasDefaultValueSql("1");

            builder.Property(x => x.tai_khoan_ngan_hang).HasMaxLength(50);
            builder.Property(x => x.ten_ngan_hang).HasMaxLength(128);

            builder.Property(q => q.loai_chuyen_khoan).IsRequired().HasDefaultValueSql("1");

            builder.Property(x => x.thanh_tien_truoc_thue).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_sau_thue).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.tien_thue).IsRequired().HasPrecision(18, 2);

            builder.Property(q => q.id_ty_le_vat).IsRequired();
            builder.Property(q => q.ty_le_vat).IsRequired();

            builder.Property(x => x.trang_thai_xuat_hang).HasDefaultValueSql("0");
            builder.Property(x => x.trang_thai_thanh_toan).HasDefaultValueSql("0");

            builder.Property(q => q.ngay_du_kien_giao).IsRequired().HasDefaultValueSql("getutcdate()");
            builder.Property(q => q.so_ngay_du_kien_giao).IsRequired().HasDefaultValueSql("0");

            builder.Property(x => x.thanh_tien_van_chuyen_truoc_thue).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien_van_chuyen_sau_thue).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.tien_thue_van_chuyen).IsRequired().HasPrecision(18, 2);

            builder.Property(q => q.ty_le_vat_van_chuyen).IsRequired();
            builder.Property(q => q.id_ty_le_vat_van_chuyen).IsRequired();


            builder.Property(q => q.id_don_vi_van_chuyen).IsRequired();
            builder.Property(x => x.ma_don_van_chuyen).IsRequired().HasMaxLength(50);

            builder.Property(q => q.id_tinh_khach_hang_nhan).IsRequired();
            builder.Property(q => q.id_quan_khach_hang_nhan).IsRequired();
            builder.Property(x => x.dia_chi_cu_the_khach_hang_dat).IsRequired().HasMaxLength(500);
            builder.Property(x => x.full_name_khach_hang_dat).IsRequired().HasMaxLength(100);
            builder.Property(x => x.first_name_khach_hang_dat).IsRequired().HasMaxLength(50);
            builder.Property(x => x.last_name_khach_hang_dat).IsRequired().HasMaxLength(50);
            builder.Property(x => x.email_khach_hang_dat).IsRequired().HasMaxLength(128);
            builder.Property(x => x.phone_khach_hang_dat).IsRequired().HasMaxLength(50);

            builder.Property(q => q.id_quan_khach_hang_dat).IsRequired();
            builder.Property(q => q.id_tinh_khach_hang_dat).IsRequired();
            builder.Property(x => x.dia_chi_cu_the_khach_hang_nhan).IsRequired().HasMaxLength(500);
            builder.Property(x => x.full_name_khach_hang_nhan).IsRequired().HasMaxLength(100);
            builder.Property(x => x.first_name_khach_hang_nhan).IsRequired().HasMaxLength(50);
            builder.Property(x => x.last_name_khach_hang_nhan).IsRequired().HasMaxLength(50);
            builder.Property(x => x.email_khach_hang_nhan).IsRequired().HasMaxLength(128);
            builder.Property(x => x.phone_khach_hang_nhan).IsRequired().HasMaxLength(50);

            builder.Property(x => x.code_kho).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ten_kho).IsRequired().HasMaxLength(128);
            builder.Property(x => x.id_kho).IsRequired();

            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
