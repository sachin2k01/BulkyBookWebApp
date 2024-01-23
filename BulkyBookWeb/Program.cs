using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;


namespace BulkyBookWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //any dependecy injection should be done here within Build(), regester database, email,etc...,  

            builder.Services.AddDbContext<BulkyDBContext>(
                x => x.UseSqlServer(builder.Configuration["connectionString:BookDB"])
               );

           // x => x.UseSqlServer(builder.Configuration["connectionString:BookDB"])

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
                pattern: "{controller=Home}/{action=actionResult}/{id?}");

            app.Run();
        }
    }
}