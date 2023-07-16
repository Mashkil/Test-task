using Microsoft.EntityFrameworkCore;
using Test_task.Data;
using Test_task.Services;

namespace Test_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<GetService>();

            builder.Services.AddDbContext<ContextDB>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<ContextDB>();

                dbContext.Database.Migrate();
            }


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Input}/{action=Input}");

            app.Run();
        }
    }
}