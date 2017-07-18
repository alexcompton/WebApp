using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApp.Core.Data;
using WebApp.Core.Service;
using WebApp.Dto;
using WebApp.Repo.MsSql;
using WebApp.Service;
using Swashbuckle.AspNetCore.Swagger;
using WebApp.Repo.DocumentDB;
using WebApp.Models;

namespace WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add repos
            services.AddTransient<IAddressRepo, AddressRepo>();
            services.AddTransient<ICustomerAddressRepo, CustomerAddressRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<IProductCategoryRepo, ProductCategoryRepo>();
            services.AddTransient<IProductDescriptionRepo, ProductDescriptionRepo>();
            services.AddTransient<IProductModelProductDescriptionRepo, ProductModelProductDescriptionRepo>();
            services.AddTransient<IProductModelRepo, ProductModelRepo>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<ISalesAddressRepo, SalesAddressRepo>();
            services.AddTransient<ISalesOrderDetailRepo, SalesOrderDetailRepo>();
            services.AddTransient<ISalesOrderHeaderRepo, SalesOrderHeaderRepo>();

            // Add services
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICustomerAddressService, CustomerAddressService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductDescriptionService, ProductDescriptionService>();
            services.AddTransient<IProductModelProductDescriptionService, ProductModelProductDescriptionService>();
            services.AddTransient<IProductModelService, ProductModelService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISalesAddressService, SalesAddressService>();
            services.AddTransient<ISalesOrderDetailService, SalesOrderDetailService>();
            services.AddTransient<ISalesOrderHeaderService, SalesOrderHeaderService>();

            // Add framework services.
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //TODO: move this to a mock IOC container
            DocumentDBRepository<Item>.Initialize();
        }
    }
}
