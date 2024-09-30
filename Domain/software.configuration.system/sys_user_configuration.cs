using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_user_configuration : IEntityTypeConfiguration<sys_user_db>
    {
        public void Configure(EntityTypeBuilder<sys_user_db> builder)
        {
            builder.ToTable("sys_user", "dbo");



            builder.Property(x => x.first_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.last_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.user_name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.full_name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.phone).HasMaxLength(50).IsRequired();
            builder.Property(x => x.token_reset_pass).HasMaxLength(500).IsRequired();
            builder.Property(x => x.type).IsRequired();


            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.update_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.phuong_thuc_thanh_toan).HasDefaultValueSql("1");
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
