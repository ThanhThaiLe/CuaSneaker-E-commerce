
using Microsoft.EntityFrameworkCore;
using software.database.Provider;

namespace cuasneaker.zapp.Installers
{
    public class SqlInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SoftwareDefautTable>(options => options.UseSqlServer(configuration.GetConnectionString("SoftwareConnection")));
        }
    }
}
