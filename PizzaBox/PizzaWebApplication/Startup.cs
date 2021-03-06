using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Abstractions;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing.TestModels;

namespace PizzaWebApplication
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
            string connectionString = Configuration.GetConnectionString("PizzaProject");

            services.AddDbContext<PizzaProjectDbContext>(options => options.UseSqlServer(connectionString));
            
            services.AddTransient<IRepositoryCustomer<Customer1>, CustomerRepository>();
            services.AddTransient<IRepositoryTempCustomerOrder<TempCustomerOrder1>, TempCustomerOrderRepo>(); 

            services.AddSingleton<Models.CustomerViewModel, Models.CustomerViewModel>();

            services.AddTransient<IRepositoryOrders<Order1>, OrderRepository>();
            services.AddTransient<IRepositoryPizza<Pizza1>, PizzaRepository>();
            services.AddTransient<IRepositoryStore<Store1>, StoreRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
