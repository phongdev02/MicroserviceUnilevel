using OfficeOpenXml;
using ReadFile.Services;
using ReadFile.Services.IServices;

namespace ReadFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add scoped services
            builder.Services.AddScoped<IFileService, FileService>();

            //Set the environment variable epplus
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            System.Environment.SetEnvironmentVariable("EPPlusLicenseContext", "NonCommercial");

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

            app.UseRouting();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
