using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Service.SetFunc;
using UserService.Service;
using UserService.Service.IService;
using Microsoft.AspNetCore.Hosting;
using UserService.Models;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Client;
using UserService.Models.Dto;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UserService.Extensions;

namespace UserService
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

            //add database
            builder.Services.AddDbContext<AppDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            //set cookie 

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(10);

                options.SlidingExpiration = true;

                // tới đường dẫn sau nếu nó đúng
                //options.LoginPath = "api/Account/Login";
                // tới đường dẫn sau nếu có sai
                //options.AccessDeniedPath = "api/Account/SetCookie";
            });

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
            
            //setting Imapper
            IMapper iMapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(iMapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //setting class
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITitleService, TitleService>();
            builder.Services.AddScoped<IJwtTokenGeneratetor, JwtTokenGeneratetor>();

            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<INPPService, NPPService>();

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following : `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },new string[]{ }
                    }
                });
            });

            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //register authen with jwt token
            //var secret = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            //var issuer = builder.Configuration.GetValue<string>("ApiSettings:Issuer");
            //var audience = builder.Configuration.GetValue<string>("ApiSettings:Audience");

            builder.AddAppAuthetication();

            builder.Services.AddAuthorization();

            //register services send email
            // Register the MailSettings configuration
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

            // Register SendGmailService
            builder.Services.AddTransient<SendGmailService>();

            IConfiguration _configuration = builder.Configuration;
            builder.Services.AddOptions();
            var mailSettings = _configuration.GetSection("MailSettings");

            builder.Services.Configure<MailSettings>(mailSettings);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseRouting();
            app.UseHttpsRedirection();
            
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers(); // Đảm bảo đã thêm điều này để kích hoạt routing cho các controllers
            //});

            addDataRoleInDB();

            app.MapControllers();

            app.Run();

            //apply migration 
            void ApplyMigrations()
            {
                using (var context = app.Services.CreateScope())
                {
                    var _db = context.ServiceProvider.GetRequiredService<AppDBContext>();

                    if (_db.Database.GetPendingMigrations().Count() > 0)
                    {
                        _db.Database.Migrate();
                    }
                }
            }

            //method add data in db
            void addDataRoleInDB()
            {
                using (var context = app.Services.CreateScope())
                {
                    var services = context.ServiceProvider;

                    new SeedData(services);
                }
            }

        }
    }
}
