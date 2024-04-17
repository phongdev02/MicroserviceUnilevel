using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Service.SetFunc;
using UserService.Service;
using UserService.Service.IService;
using Microsoft.AspNetCore.Hosting;
using UserService.Models;


namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add database
            builder.Services.AddDbContext<AppDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //setting Imapper
            IMapper iMapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(iMapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //setting class
            builder.Services.AddScoped<ITaikhoanService, TaikhoanService>();
            builder.Services.AddScoped<IChucvuService, ChucvuService>();
            
            builder.Services.AddScoped<IKhuvucService, KhuvucService>();
            builder.Services.AddScoped<INPPService, NPPService>();

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // setting JWT
            /*var secret = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:Issuer");
            var audience = builder.Configuration.GetValue<string>("ApiSettings:Audience");

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true
                };
            });
            builder.Services.AddAuthorization();*/


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthentication();
            addDataRoleInDB();

            app.UseAuthorization();

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
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    new SeedData(services);
                }
            }
        }
    }
}
