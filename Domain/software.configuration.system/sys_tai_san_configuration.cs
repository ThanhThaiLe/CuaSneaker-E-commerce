using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_tai_san_configuration : IEntityTypeConfiguration<sys_tai_san_db>
    {
        public void Configure(EntityTypeBuilder<sys_tai_san_db> builder)
        {
            builder.ToTable("sys_tai_san", "dbo");


            builder.Property(x => x.code).HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.code).IsUnique();
            builder.Property(x => x.name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.unsigned_name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.address).IsRequired().HasMaxLength(500);
            builder.Property(q => q.id_doi_tuong).IsRequired();
            builder.Property(q => q.nam_san_xuat).IsRequired();
            builder.Property(q => q.ngay_het_han).IsRequired();
            builder.Property(q => q.id_don_vi_tinh).IsRequired();
            builder.Property(q => q.id_nhan_hieu).IsRequired();
            builder.Property(q => q.so_luong).IsRequired();


            builder.Property(x => x.serial).HasMaxLength(128);
            builder.Property(x => x.xuat_xu).HasMaxLength(128);

            builder.Property(x => x.don_gia).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.thanh_tien).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.so_tien_thanh_ly).IsRequired().HasPrecision(18, 2);

            builder.Property(x => x.ngay_bao).HasDefaultValueSql("getutcdate()");




            builder.Property(x => x.kh_ngay_tinh_khau_hao).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.kh_ngay_ket_thuc_khau_hao).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.kh_gia_tri_khau_hao_trong_mot_ky).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.kh_gia_tri_da_khau_hao).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.kh_gia_tri_con_lai).IsRequired().HasPrecision(18, 2);




            builder.Property(x => x.pb_ngay_tinh_phan_bo).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.pb_ngay_ket_thuc_phan_bo).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.pb_gia_tri_phan_bo_trong_mot_ky).HasPrecision(18, 2);
            builder.Property(x => x.pb_gia_tri_da_phan_bo).HasPrecision(18, 2);
            builder.Property(x => x.pb_gia_tri_con_lai).HasPrecision(18, 2);



            builder.Property(x => x.tai_khoan_chi_phi).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_nguyen_gia).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_khau_hao).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_phan_bo).HasMaxLength(128);
            builder.Property(x => x.id_phieu_nhap_kho).HasMaxLength(128);
            builder.Property(x => x.id_don_hang_mua).HasMaxLength(128);
            builder.Property(x => x.id_phieu_nhap_kho_chi_tiet).HasMaxLength(128);

            builder.Property(x => x.ly_do).HasMaxLength(500).IsRequired();
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
