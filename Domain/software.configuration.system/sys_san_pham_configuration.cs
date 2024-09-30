using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_san_pham_configuration : IEntityTypeConfiguration<sys_san_pham_db>
    {
        public void Configure(EntityTypeBuilder<sys_san_pham_db> builder)
        {
            builder.ToTable("sys_san_pham", "dbo");



            builder.HasIndex(q => q.ma_san_pham).IsUnique();

            builder.Property(x => x.ten_san_pham).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ma_san_pham).HasMaxLength(50).IsRequired();
            builder.Property(x => x.id_loai_san_pham).IsRequired();
            builder.Property(x => x.id_nhan_hieu).IsRequired();
            builder.Property(x => x.id_don_vi_tinh).IsRequired();
            builder.Property(x => x.hinh_anh).IsRequired();


            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);


        }
    }
}
