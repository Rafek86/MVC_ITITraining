using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container. => register in Container
            //1-Builde in Service and Already register in IOC Container "IConfiguration"
            //2-Builde in Service but not register in IOC Container "AddSession"
            builder.Services.AddDbContext<ITIEntity>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            //Add filter on all application controllers 
            builder.Services.AddControllersWithViews();//option =>option.Filters.Add-+
            //Vuilt in Filters like Autherization logging

            builder.Services.AddSession();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();  
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();  


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ITIEntity>();
            //builder.Services.AddScoped<interface name, Class name> => any one use the interface Create object with class type 

            var app = builder.Build();
            #region InlineComponent

            ////use => Excute and Call the next element
            //app.Use(
            //    async(httpContext, next) =>
            //    {
            //        await httpContext.Response.WriteAsync("1)Middel Ware 1\n");
            //        await next.Invoke();
            //        await httpContext.Response.WriteAsync("1)Middel Ware 1\n");

            //    });

            //app.Use(async (httpContext,next) => {
            //    await httpContext.Response.WriteAsync("2(MIddel Ware 2\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("2(MIddel Ware 2\n");


            //});

            //app.Run(async (httpContext) => {
            //    await httpContext.Response.WriteAsync("3(Terminate\n");
            //}); 
            #endregion
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//wwwrot Files(HTML ,CSS ,JS)

            app.UseRouting();

            app.UseAuthentication();//filter Authorize "Cookie"
            app.UseAuthorization();
            app.UseSession();

            //app.MapControllerRoute(
            //     name: "Employee",
            //     pattern: "emp/{id:int}",
            //     defaults: new { controller = "Employee", action = "Details" }
            // );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
