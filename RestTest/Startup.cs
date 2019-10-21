using System;
using RestTest.Core;
using RestTest.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RestTest
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
            //mapper config
            var mapperConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new Api.Models.Mapping.RequestsProfile());
                 mc.AddProfile(new Infrastructure.Data.Mapping.DataProfiles());
             });
            mapperConfig.CompileMappings();
            services.AddSingleton(mapperConfig.CreateMapper());

            //swagger config
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new  OpenApiInfo { Title = "RestTestApi" });
            });

            services.AddControllers();

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfrastructureModule());

            //preseneters reflection registering automatically
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestTestWebApi v1");
            });
            app.UseSwagger();
        }
    }
}
