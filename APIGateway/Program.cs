namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add the reverse proxy capability to the server
            builder.Services.AddReverseProxy()
                // Initialize the reverse proxy from the "ReverseProxy" section of configuration
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
