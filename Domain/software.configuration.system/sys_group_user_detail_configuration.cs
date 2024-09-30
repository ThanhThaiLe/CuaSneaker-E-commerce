using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_group_user_detail_configuration : IEntityTypeConfiguration<sys_group_user_detail_db>
    {
        public void Configure(EntityTypeBuilder<sys_group_user_detail_db> builder)
        {
            builder.ToTable("sys_group_user_detail", "dbo");

        }
    }
}
