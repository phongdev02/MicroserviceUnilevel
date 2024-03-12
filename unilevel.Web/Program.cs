using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using unilevel.Web.Service;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // addd service to controller
            builder.Services.AddControllersWithViews();
            // setting cookies
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<INhanvienService, NhanvienService>();
            builder.Services.AddHttpClient<IAuthService, AuthService>();

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<INhanvienService, NhanvienService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            //register authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(10);
                
                options.SlidingExpiration = true;
                
                // tới đường dẫn sau nếu nó đúng
                options.LoginPath = "/Auth/Login";
                // tới đường dẫn sau nếu có sai
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            SD.NhanvienApiBase = builder.Configuration["ServiceUrls:NhanvienAPI"];
            SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

            builder.Services.AddScoped<ITokenProvider, TokenProvider>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
