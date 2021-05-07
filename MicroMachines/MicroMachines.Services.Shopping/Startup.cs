using MicroMachines.Common.Middlewares;
using MicroMachines.Services.Shopping.Clients;
using MicroMachines.Services.Shopping.Data.Context;
using MicroMachines.Services.Shopping.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace MicroMachines.Services.Shopping
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroMachines.Services.Shopping", Version = "v1" });
            });

            services.AddDbContext<ShoppingContext>(options =>
                options.UseInMemoryDatabase(databaseName: "ShoppingDb"));

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestResponseLoggingMiddleware>();

            services.AddHttpClient<CatalogClient>(client =>
            {
                client.BaseAddress = Configuration.GetValue<Uri>("CatalogUrl");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroMachines.Services.Shopping v1"));
            }

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();

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
