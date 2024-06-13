using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using MovieStoreMVC.Models;
using MovieStoreMVC.Services;
using System.Configuration;

namespace MovieStoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
//Register the context in Startup.cs:
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<MovieStoreContext>(options =>
//        options.UseSqlServer(Configuration.GetConnectionString("MovieStoreContext")));
//    services.AddControllersWithViews();
//}
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddDbContext<MovieStoreContext>(options =>
//        options.UseSqlServer(Configuration.GetConnectionString("MovieStoreContext")));
//    services.AddScoped<ShoppingCartService>();
//    services.AddHttpContextAccessor();
//    services.AddSession();
//    services.AddControllersWithViews();
//}

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();
//    }
//    else
//    {
//        app.UseExceptionHandler("/Home/Error");
//        app.UseHsts();
//    }
//    app.UseHttpsRedirection();
//    app.UseStaticFiles();

//    app.UseRouting();

//    app.UseAuthorization();
//    app.UseSession();

//    app.UseEndpoints(endpoints =>
//    {
//        endpoints.MapControllerRoute(
//            name: "default",
//            pattern: "{controller=Home}/{action=Index}/{id?}");
//    });
//}
