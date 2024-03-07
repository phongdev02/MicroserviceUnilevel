using ChucvuPhanquyen.Context;
using ChucvuPhanquyen.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ChucvuPhanquyen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add db
            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //add data on table db Role
            builder.Services.AddScoped<AppDBContext>();

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

            //add data in db
            addDataRoleInDB();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();


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
