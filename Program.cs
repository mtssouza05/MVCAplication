using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext
            builder.Services.AddDbContext<ProdutoContext>(options => options.UseSqlServer("Data Source=ESGHL-TI04\\SQLEXPRESS;Initial Catalog=ProdutoDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;"

));

            // Ignore SSL certificate verification for development environment
            if (builder.Environment.IsDevelopment())
            {
                //This line accepts any SSL certificate, use only for development
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;
            }


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

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