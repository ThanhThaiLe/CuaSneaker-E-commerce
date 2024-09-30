using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_thong_tin_website_configuration : IEntityTypeConfiguration<sys_thong_tin_website_db>
    {
        public void Configure(EntityTypeBuilder<sys_thong_tin_website_db> builder)
        {
            builder.ToTable("sys_thong_tin_website", "dbo");




            builder.Property(x => x.image_logo).IsRequired();
            builder.Property(x => x.image_footer).IsRequired();
            builder.Property(x => x.dia_chi).HasMaxLength(500).IsRequired();
            builder.Property(x => x.so_dien_thoai).HasMaxLength(50).IsRequired();
            builder.Property(x => x.email).HasMaxLength(50).IsRequired();

            builder.Property(x => x.link_facebook).HasMaxLength(500).IsRequired();
            builder.Property(x => x.link_youtube).HasMaxLength(500).IsRequired();
            builder.Property(x => x.link_linkedin).HasMaxLength(500).IsRequired();
            builder.Property(x => x.link_instagram).HasMaxLength(500).IsRequired();



            builder.Property(x => x.note).HasMaxLength(500).IsRequired();
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
