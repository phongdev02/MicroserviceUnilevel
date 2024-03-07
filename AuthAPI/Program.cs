using AuthAPI.Context;
using AuthAPI.Models;
using AuthAPI.Service;
using AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AuthAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add db
            builder.Services.AddDbContext<AppDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //chuyen doi tu trong file setting de co the su dung bang class
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

            // cau hinh mot so table da duoc .net cau hinh san
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGeneratetor,  JwtTokenGeneratetor>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            applyMigration();

            app.Run();

            void applyMigration()
            {
                using ( var scope = app.Services.CreateScope() )
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                    if(db.Database.GetPendingMigrations().Any())
                    {
                        db.Database.Migrate();
                    }
                }
            }
        }
    }
}
