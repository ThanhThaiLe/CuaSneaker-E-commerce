using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace software.common.Model
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("SoftwareConnection"));
        }
    }
}
