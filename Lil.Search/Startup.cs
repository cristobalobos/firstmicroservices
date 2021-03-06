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
using Lil.Search.Interfaces;
using Lil.Search.Services;


namespace Lil.Search
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

            services.AddSingleton<ICustomersService, CustomersService>();
            services.AddSingleton<IProductsService, ProductService>();
            services.AddSingleton<ISalesService, SalesService>();
            

            services.AddHttpClient("customersService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Service:Customers"]);
            });

            services.AddHttpClient("productsService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Service:Products"]);
            });

            services.AddHttpClient("salesService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Service:Sales"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
