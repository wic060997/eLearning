using Autofac;
using Backend.Auth.Helpers;
using Backend.Auth.Services;
using Backend.Autofac;
using Backend.Services;
using Infrastructure.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Model.UserModel.Entity;
using NLog.Extensions.Logging;
using Persistance.UserRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; set; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }


        public void ConfigureServices(IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });

            services.AddControllers();

            CreateLogger(services);

            services.AddScoped<IScopedService, ScopedService>();
            services.AddCronJob<WorkCron>(elem =>
            {
                elem.TimeZoneInfo = TimeZoneInfo.Local;
                elem.CronExpression = @"0 1 * * *";
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            app.UseRouting();

            //app.UseCors(config =>
            //    config.AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowAnyOrigin()
            //);

            app.UseCors("CorsPolicy");

            app.UseSwagger();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend");
                c.RoutePrefix = string.Empty;
            });

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());

            appLifetime.ApplicationStopped.Register(OnShutdown);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly persisntaceAssembly = typeof(UsersRepository).Assembly;
            Assembly modelAssembly = typeof(Users).Assembly;

            builder.RegisterModule(new PersistnaceModule(this.Configuration.GetConnectionString("DefaultConnection"), persisntaceAssembly, modelAssembly));
            builder.RegisterModule(new ApplicationDomainModule(modelAssembly));
            builder.Register(c => new TransactionInterceptor()).InstancePerDependency();
            builder.RegisterModule(new InfrastructureModule());
        }

        private void CreateLogger(IServiceCollection services)
        {

            NLog.Config.LoggingConfiguration nlogConfig = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
            NLog.LogManager.Configuration = nlogConfig;

            services.AddLogging(configure => configure.AddNLog(Configuration));

        }

        private void OnShutdown()
        {
            if (ApplicationContainer != null)
            {
                ApplicationContainer.Dispose();
            }
        }
    }
}
