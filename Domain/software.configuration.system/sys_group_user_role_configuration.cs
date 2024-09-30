using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using software.entity.system;

namespace software.configuration.system
{
    public class sys_group_user_role_configuration : IEntityTypeConfiguration<sys_group_user_role_db>
    {
        public void Configure(EntityTypeBuilder<sys_group_user_role_db> builder)
        {
            builder.ToTable("sys_group_user_role", "dbo");

        }
    }
}
