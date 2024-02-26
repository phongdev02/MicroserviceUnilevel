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
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<INhanvienService, NhanvienService>();

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<INhanvienService, NhanvienService>();

            SD.NhanvienApiBase = builder.Configuration["ServiceUrls:NhanvienAPI"];

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

            app.Run();
        }
    }
}
