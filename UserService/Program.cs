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


            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

            //setting Imapper
            IMapper iMapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(iMapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //setting class
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITitleService, TitleService>();
            builder.Services.AddScoped<IJwtTokenGeneratetor,  JwtTokenGeneratetor>();

            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<INPPService, NPPService>();

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

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
