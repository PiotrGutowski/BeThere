using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeThere.Infrastructure.Authentication.Extensions;
using Autofac;
using BeThere.DAL;
using BeThere.Infrastructure.IoC.Modules;
using BeThere.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BeThere.Api.Framework;
using BeThere.DAL.Users.Repositories;
using BeThere.Infrastructure.Users;
using Swashbuckle.AspNetCore.Swagger;
using NLog.Extensions.Logging;
using NLog.Web;
using Autofac.Extensions.DependencyInjection;

namespace BeThere.Api
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Infrastructure.Mappings.AutoMapperConfiguration.Configure();


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.ConfiguredJwt();
            services.AddMemoryCache();
            services.AddMvc();
            services.AddCors();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddDistributedRedisCache(r => { r.Configuration = Configuration["redis:connectionString"]; });
            services.AddDbContext<BeThereDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Be There", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();



            return new AutofacServiceProvider(ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
           
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseExceptionHandlerMiddleware();
            }
            app.UseAuthentication();
        
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());

            app.UseMvc();
  
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Be There V1");
            });

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
