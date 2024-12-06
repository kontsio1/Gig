using System.Security.Cryptography;
using GigApp.Application;
using GigApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// string connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

IConfigurationRoot appConfig = new ConfigurationBuilder() //this is builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .AddCommandLine(args) //ex dotnet run --environment=dev
    .AddUserSecrets<Program>()
    .Build();

// builder.Services.Configure<ConnectionStrings>(o =>
//     builder.Configuration.GetSection(ConnectionStrings.SectionName).Bind(o)
// );
// for full view of IConfig providers use appConfig.GetDebugView().ToString();

var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>(); //this is builder.Services.AddDbContext<ApplicationDbContext
optionBuilder.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsHistoryTable("_EfMigrations")
);

// builder.Services.AddDataProtection();

// builder.Services.AddScoped<IMyDependency, MyDependency>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

// ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
