namespace cuasneaker.zapp.Installers
{
    public static class InstallerExtensions
    {
        //public static void InstallerServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        //{
        //    // Lấy các loại cài đặt từ assembly của Startup
        //    var installers = typeof(Program).Assembly.ExportedTypes
        //        .Where(q => typeof(IInstaller).IsAssignableFrom(q) && !q.IsInterface && !q.IsAbstract)
        //        .Select(Activator.CreateInstance)
        //        .Cast<IInstaller>()
        //        .ToList();

        //    // Cài đặt các dịch vụ bằng cách sử dụng các
        //    installers.ForEach(installer => installer.InstallServices(services, configuration));
        //}
    }
}
