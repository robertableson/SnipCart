using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using snipcart;

namespace snipcart
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<InMemoryDB>(opt => opt.UseInMemoryDatabase());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var context = app.ApplicationServices.GetService<InMemoryDB>();
            AddTestData(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AddTestData(InMemoryDB context)
        {
            var testProd1 = new snipcart.Models.Product
            {
                Title = "Jordans S2K Sr edition",
                Description = "The Jordans S2K Sr edition is the best bang for your buck.", 
                Price = 97.99,
                Sku = "Pk-536-SL",
                Image = "http://simpleproductphotography.com/wp-content/uploads/2016/06/huf-converse-product-red-skidgrip-1.jpg"
            };
            var testProd2 = new snipcart.Models.Product
            {
                Title = "Lamborghini Huracan",
                Description = "The Lamborghini Huracan is definitely the best supercar for the money.", 
                Price = 278999.99,
                Sku = "LK-674-HG",
                Image = "http://1.bp.blogspot.com/-Gaj30dheGzE/VfGQL2uD0_I/AAAAAAAAWJ4/IOomh6RXDpY/w800/lambo-huracan-roadster-rendering-ts-4.jpg"
            };
        
            context.Products.Add(testProd1);
            context.Products.Add(testProd2);
            context.SaveChanges();
        }
    }
}
