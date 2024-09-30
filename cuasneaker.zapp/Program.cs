using cuasneaker.zapp.Installers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using software.common.BaseClass;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using software.web.erp.MenuAndRole;
using software.web.MenuAndRole;
using software.web.portal.MenuAndRole;
using StackExchange.Redis;
using System.Text;
using tusdotnet;
using tusdotnet.Models;
using tusdotnet.Models.Expiration;
using tusdotnet.Stores;

var builder = WebApplication.CreateBuilder(args);


// Lấy các loại cài đặt từ assembly của Startup
var installers = typeof(Program).Assembly.ExportedTypes
    .Where(q => typeof(IInstaller).IsAssignableFrom(q) && !q.IsInterface && !q.IsAbstract)
    .Select(Activator.CreateInstance)
    .Cast<IInstaller>()
    .ToList();

// Cài đặt các dịch vụ bằng cách sử dụng các installer
installers.ForEach(installer => installer.InstallServices(builder.Services, builder.Configuration));
// AppSettings
var appsettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSetting>(appsettingSection);
var appsettings = appsettingSection.Get<AppSetting>();

// Mail Settings
var mailSection = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSection);
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddScoped<IUserService, UserService>();
// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
{
    var configure = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configure);
});

// SQL Database Context
builder.Services.AddDbContext<SoftwareDefautTable>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoftwareConnection")));

// Sử dụng NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(setup =>
{
    setup.SerializerSettings.ContractResolver = new DefaultContractResolver();
    setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    setup.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
});

// Thêm IdentityServer với InMemory config
builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddDeveloperSigningCredential();

// Thêm MVC và InputFormatters
builder.Services.AddMvc(options =>
{
    options.InputFormatters.Add(new RawRequestBodyFormatter());
}).AddNewtonsoftJson(setup =>
    setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Đăng ký SoftwareAuthorize
builder.Services.AddTransient<SoftwareAuthorize>();

// Thêm HttpClient và Session
builder.Services.AddHttpClient();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
    option.Cookie.HttpOnly = true;
});

// Thêm Authentication và JwtBearer
var key = Encoding.ASCII.GetBytes(appsettings.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var user_id = context.Principal.Identity.Name;
            if (user_id == null)
            {
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    };
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Thêm hỗ trợ cho RazorPages và ControllersWithViews
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Nếu ở môi trường sản xuất, phục vụ các file Angular SPA
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

// Đăng ký Tus file upload
builder.Services.AddSingleton(CreateTusConfiguration);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage(); // Hiển thị lỗi liên quan đến Database trong môi trường phát triển
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseTus(httpContext => Task.FromResult(httpContext.RequestServices.GetService<DefaultTusConfiguration>()));
app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}
else
{
    app.UseHttpsRedirection();
}

app.UseRouting();
// Thêm IdentityServer, Session, và Authentication vào pipeline
app.UseIdentityServer();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
// Định tuyến cho API và Razor Pages
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}.ctr/{action=Index}/{id?}");
    endpoints.MapRazorPages(); // Định tuyến cho Razor Pages
});


// Cấu hình Angular SPA
app.UseSpa(spa =>
{
    // Định nghĩa đường dẫn cho Angular client
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        // Proxy tới server Angular CLI nếu đang ở môi trường dev
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
    }
});


ListController.list = new List<ControllerAppModel>();
ListController.list.AddRange(SystemMenuAndRole.list);
ListController.list.AddRange(PortalMenuAndRole.list);
ListController.list.AddRange(ErpMenuAndRole.list);
ListController.listpublicactioncontroller = new List<string>();
ListController.listpublicNonactioncontroller = new List<string>();
for (int i = 0; i < ListController.list.Count(); i++)
{
    ListController.listpublicactioncontroller.AddRange(ListController.list[i].list_controller_action_public.Select(q => q.ToLower()));
    ListController.listpublicNonactioncontroller.AddRange(ListController.list[i].list_public_Non_action_controller.Select(q => q.ToLower()));
}

app.Run();

DefaultTusConfiguration CreateTusConfiguration(IServiceProvider serviceProvider)
{
    var appsettings = builder.Configuration.GetSection("AppSettings");
    var _appsettings = appsettings.Get<AppSetting>();
    var tus = Path.Combine(_appsettings.folder_path, "file_upload", "tempFileTus");

    return new DefaultTusConfiguration
    {
        UrlPath = "/tus",
        Store = new TusDiskStore(tus),
        MetadataParsingStrategy = MetadataParsingStrategy.AllowEmptyValues,
        Expiration = new AbsoluteExpiration(TimeSpan.FromMinutes(120)),
        Events = new tusdotnet.Models.Configuration.Events
        {
            OnFileCompleteAsync = async ct =>
            {
                var file = await ct.GetFileAsync();
                var metadatas = await file.GetMetadataAsync(ct.CancellationToken);
                var file_name_metadata = metadatas["fileName"];
                var file_name = file_name_metadata.GetString(Encoding.UTF8).Trim('"');
                var id = metadatas["id"].GetString(Encoding.UTF8);

                var path = Path.Combine(_appsettings.folder_path, "file_upload", id);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var pathSave = Path.Combine(path, ct.FileId + "." + file_name.Split(".").Last());
                File.Move(Path.Combine(tus, ct.FileId), pathSave);

                var tempFiles = new[] { ".chunkcomplete", ".chunkstart", ".expiration", ".metadata", ".uploadlength" }
                    .Select(ext => Path.Combine(tus, ct.FileId) + ext);

                foreach (var tempFile in tempFiles)
                {
                    File.Delete(tempFile);
                }
            }
        }
    };
}
