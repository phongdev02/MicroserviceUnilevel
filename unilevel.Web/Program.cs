using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using unilevel.Web.Service;
using unilevel.Web.Service.API;
using unilevel.Web.Service.IAPI;
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
            builder.Services.AddHttpClient<IAccountService, AccountService>();

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAreaApiService, AreaApiService>();
            builder.Services.AddScoped<IAreaService,  AreaService>();

            //register design patten scoped
            builder.Services.AddScoped<IAccountAPIService, AccountAPIService>();
            builder.Services.AddScoped<IAreaApiService, AreaApiService>();

            //register authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(10);

                options.SlidingExpiration = true;

                // tới đường dẫn sau nếu nó đúng
                //options.LoginPath = "api/Account/Login";
                // tới đường dẫn sau nếu có sai
                //options.AccessDeniedPath = "api/Account/AccessDenied";
            });

            SD.UserApiBase = builder.Configuration["ServiceUrls:UserAPI"];

            builder.Services.AddScoped<ITokenProvider, TokenProvider>();

            //add service http context
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            builder.Services.AddScoped<IUrlHelper>(x => {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

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
