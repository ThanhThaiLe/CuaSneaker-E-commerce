using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.erp;

namespace software.configuration.erp
{
    public class erp_hoa_don_ban_hang_configuration : IEntityTypeConfiguration<erp_hoa_don_ban_hang_db>
    {
        public void Configure(EntityTypeBuilder<erp_hoa_don_ban_hang_db> builder)
        {
            builder.ToTable("erp_hoa_don_ban_hang", "dbo");

            builder.Property(x => x.so_seri).IsRequired().HasMaxLength(50);
            builder.Property(x => x.id_don_hang_ban).IsRequired();
            builder.Property(x => x.loai_hoa_don).IsRequired();
            builder.Property(x => x.ngay_ghi_hoa_don).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.trang_thai_phat_sinh).HasDefaultValueSql("1");
            builder.Property(x => x.hinh_thuc_doi_tuong).HasDefaultValueSql("1");
            builder.Property(x => x.id_doi_tuong).IsRequired().HasMaxLength(128);

            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
