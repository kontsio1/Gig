using System.Reflection;
using System.Security.Cryptography;
using GigApp.Models;
using GigApp.Models.Users;
using GigApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

IConfigurationRoot appConfig = new ConfigurationBuilder() //this is builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .AddCommandLine(args) //ex dotnet run --environment=dev
    .AddUserSecrets<Program>()
    .Build();

builder.Services.AddDbContext<ApplicationDbContext>((_, optionBuilder) =>
{
    optionBuilder.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("_EfMigrations"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// builder.Services.AddDataProtection();
// builder.Services.Configure<ConnectionStrings>(o =>
//     builder.Configuration.GetSection(ConnectionStrings.SectionName).Bind(o)
// );
// for full view of IConfig providers use appConfig.GetDebugView().ToString();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
