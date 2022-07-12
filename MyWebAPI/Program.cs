//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



using Microsoft.EntityFrameworkCore;
using MyWebAPI;

//var builder = WebApplication.CreateBuilder(args);
//var startup = new Startup(builder.Configuration,);
//startup.ConfigureServices(builder.Services);
//var app = builder.Build();
//startup.Configure(app);
//app.Run();





public class Program
{
    public static void Main(string[] args)
    {
        var path = Directory.GetCurrentDirectory();
        var contextOptions = new DbContextOptionsBuilder<portal_dal.PortalDbContext>()
    .UseSqlite($"Data Source={ System.IO.Path.Join(path, "/SqlliteDB/portal.db")}")
    .Options;


        using (var context = new portal_dal.PortalDbContext(contextOptions))
        {
            UserSeeder.Initialize(context);
        }


        var host = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .Build();

        host.Run();
    }
}