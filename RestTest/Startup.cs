using System;
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RestTest.Infrastructure.Data.Mapping.DataProfiles));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "RestTestApi" });
            });

            services.AddControllers();

            //dependency injection with autofac
            var builder = new ContainerBuilder();

            //TODO
            //builder.RegisterModule(new CoreModule());
            //builder.RegisterModule(new InfrastructureModule());

            //preseneters reflection registering automatically
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();

            builder.Populate(services);
            var container = builder.Build();

            return new AutofacServiceProvider(container);
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
