using software.repo.portal;

namespace cuasneaker.zapp.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperPortalProfile).Assembly);
        }
    }
}
