using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_xuat_kho_chi_tiet_configuration : IEntityTypeConfiguration<erp_xuat_kho_chi_tiet_db>
    {
        public void Configure(EntityTypeBuilder<erp_xuat_kho_chi_tiet_db> builder)
        {
            builder.ToTable("erp_xuat_kho_chi_tiet", "dbo");

            builder.Property(x => x.id_phieu_xuat).IsRequired();
            builder.Property(x => x.id_mat_hang).IsRequired();
            builder.Property(x => x.id_don_vi_tinh).IsRequired();
            builder.Property(x => x.so_luong).IsRequired();
            builder.Property(x => x.don_gia).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.don_gia_von).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.gia_tri).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.gia_tri_gia_von).IsRequired().HasPrecision(18, 2);

            builder.Property(x => x.ngay_xuat).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.is_dinh_khoan).HasDefaultValueSql("0");
            builder.Property(x => x.tai_khoan_co).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_no).HasMaxLength(128);
            builder.Property(x => x.doi_tuong_no).HasMaxLength(128);
            builder.Property(x => x.doi_tuong_co).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_no_gia_von).HasMaxLength(128);
            builder.Property(x => x.tai_khoan_co_gia_von).HasMaxLength(128);
            builder.Property(x => x.id_loai_xuat).IsRequired();
            builder.Property(x => x.id_kho).IsRequired();
            builder.Property(x => x.is_vat).HasDefaultValueSql("0");
            builder.Property(x => x.ty_suat_vat).HasDefaultValueSql("0");



            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
