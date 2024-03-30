using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using software.common.BaseClass;
using software.common.Common;
using software.common.Model;
using software.common.Service;
using software.database.Provider;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tusdotnet;
using tusdotnet.Models;
using tusdotnet.Models.Expiration;
using tusdotnet.Stores;

namespace software.zapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("SoftwareConnection")));
            var appsettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appsettingSection);
            var mailSection = Configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailSection);
            var appsettings = appsettingSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appsettings.Secret);
            services.AddDbContext<SoftwareDefautTable>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SoftwareConnection")));

            services.AddControllers().AddNewtonsoftJson(setup =>
            {
                setup.SerializerSettings.ContractResolver = new DefaultContractResolver();
                setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                setup.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
            });
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddMvc(options =>
            {
                options.InputFormatters.Add(new RawRequestBodyFormatter());
            }).AddNewtonsoftJson(setup => setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthentication(options =>
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
                            context.Fail("Unauthor");
                        }
                        return Task.CompletedTask;
                    }
                };
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            services.AddTransient<SoftwareAuthorize>();
            services.AddTransient<IMailService, MailService>();
            services.AddHttpClient();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(20);
                option.Cookie.HttpOnly = true;
            });
            services.AddAuthentication().AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(CreateTusConfiguration);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }
        private DefaultTusConfiguration CreateTusConfiguration(IServiceProvider serviceProvider)
        {
            var appsettings = Configuration.GetSection("AppSettings");
            var _appsettins = appsettings.Get<AppSetting>();
            var env = (IWebHostEnvironment)serviceProvider.GetRequiredService(typeof(IWebHostEnvironment));
            var tus = Path.Combine(_appsettins.folder_path, "file_upload", "tempFileTus");
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
                        var file_name = file_name_metadata.GetString(Encoding.UTF8).Trim('"') + "";
                        var id = metadatas["id"].GetString(Encoding.UTF8);

                        var path = Path.Combine(_appsettins.folder_path, "file_upload", id);
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        var tick = Guid.NewGuid().ToString();
                        var pathSave = Path.Combine(path, ct.FileId + "." + file_name.Split(".").Last());

                        File.Move(Path.Combine(tus, ct.FileId), pathSave);
                        File.Delete(Path.Combine(tus, ct.FileId));
                        File.Delete(Path.Combine(tus, ct.FileId) + ".chunkcomplete");
                        File.Delete(Path.Combine(tus, ct.FileId) + ".chunkstart");
                        File.Delete(Path.Combine(tus, ct.FileId) + ".expiration");
                        File.Delete(Path.Combine(tus, ct.FileId) + ".metadata");
                        File.Delete(Path.Combine(tus, ct.FileId) + ".uploadlength");
                    }
                }
            };
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseTus(httpContext => Task.FromResult(httpContext.RequestServices.GetService<DefaultTusConfiguration>()));

            //
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            else
            {
                app.UseHttpsRedirection();
            }
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}.ctr/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

                }
            });
        }
    }
}
