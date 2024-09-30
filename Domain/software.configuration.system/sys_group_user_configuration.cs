using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_group_user_configuration : IEntityTypeConfiguration<sys_group_user_db>
    {
        public void Configure(EntityTypeBuilder<sys_group_user_db> builder)
        {
            builder.ToTable("sys_group_user", "dbo");

            builder.Property(x => x.name).HasMaxLength(500);
            builder.HasIndex(x => x.name).IsUnique();
            builder.Property(x => x.status_del).HasDefaultValueSql("1");
            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
