using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_file_upload_configuration : IEntityTypeConfiguration<sys_file_upload_db>
    {
        public void Configure(EntityTypeBuilder<sys_file_upload_db> builder)
        {
            builder.ToTable("sys_file_upload", "dbo");


            builder.Property(x => x.file_size).HasDefaultValueSql("0");
            builder.Property(x => x.file_type).HasMaxLength(500).IsRequired();
            builder.Property(x => x.id_parent).HasMaxLength(500).IsRequired();
            builder.Property(x => x.controller).HasMaxLength(128).IsRequired();
            builder.Property(x => x.file_name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.file_path).IsRequired();


            builder.Property(x => x.note).HasMaxLength(500);
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_date).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.create_by).HasMaxLength(128);
            builder.Property(x => x.create_date).HasMaxLength(128);
        }
    }
}
