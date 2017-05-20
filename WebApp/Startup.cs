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
using WebApp.Repo.DocumentDB;
using WebApp.Models;
using Swashbuckle.AspNetCore.Swagger;
using WebApp.Core.Data;
using WebApp.Repo.MsSql;
using WebApp.Core.Data.Dao;

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
            // Add Repos
            services.Add(new ServiceDescriptor(typeof(IRepo<AddressDao>), p => new AddressRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<CustomerAddressDao>), p => new CustomerAddressRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<CustomerDao>), p => new CustomerRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<ProductCategoryDao>), p => new ProductCategoryRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<ProductDescriptionDao>), p => new ProductDescriptionRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<ProductModelProductDescriptionDoa>), p => new ProductModelProductDescriptionRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<ProductModelDao>), p => new ProductModelRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<ProductDao>), p => new ProductRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<SalesOrderDetailDao>), p => new SalesOrderDetailRepo(), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRepo<SalesOrderHeaderDao>), p => new SalesOrderHeaderRepo(), ServiceLifetime.Transient));

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
