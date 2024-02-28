using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaiKhoan.Context;
using TaiKhoan.service;
using TaiKhoan.service.IService;

namespace TaiKhoan
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            ApplyMigrations();

            app.Run();

            //apply migration 
            void ApplyMigrations()
            {
                using (var context = app.Services.CreateScope())
                {
                    var _db = context.ServiceProvider.GetRequiredService<AppDBContext>();

                    if(_db.Database.GetPendingMigrations().Count() > 0)
                    {
                        _db.Database.Migrate();
                    }
                }
            }
        }
    }
}
