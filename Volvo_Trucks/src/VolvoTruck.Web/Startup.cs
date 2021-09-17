using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolvoTruck.DI;
using VolvoTruck.DI.Registers;

namespace VolvoTruck.Web
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
            AddCors(services);

            ContextRegister.Configure(services, Configuration.GetConnectionString("DefaultConnection"));
            ServicesRegister.Configure(services);
            RepositoriesRegister.Configure(services);


            services.AddSwaggerGen();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Volvo Truck API V1");
            });
            this.UseCors(app);

            app.UseMvc();
        }

        private void UseCors(IApplicationBuilder app)
        {
            app.UseCors(
                options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
        }

        private void AddCors(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
