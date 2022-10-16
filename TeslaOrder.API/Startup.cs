using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TeslaOrder.API.Extensions;
using TeslaOrder.Core;
using TeslaOrder.Infrastruture;

namespace TeslaOrder.API
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
            services.AddControllers();
            services.AddMediatRServices();
            services.AddMySqlDomainContext(Configuration.GetValue<string>("Mysql"));
            services.AddRepositories();

            services.AddSwaggerGen(swaggerGenOptions =>
            {
                typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
                {
                    swaggerGenOptions.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Tesla Open API",
                        Version = version,
                        Description = $"Tesla Open API {version} Powered by ASP.NET Core"
                    });
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGenOptions.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dc = scope.ServiceProvider.GetService<DomainContext>();
                dc.Database.EnsureCreated();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(swaggerUIOptions =>
            {
                typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
                {
                    swaggerUIOptions.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
