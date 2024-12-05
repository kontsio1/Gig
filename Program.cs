using System.Security.Cryptography;
using GigApp.Application;
using GigApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// string connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

var config = builder.Configuration;
var connectionString = config.GetConnectionString("DefaultConnection");

// var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
// optionBuilder.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("_EfMigrations"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("_EfMigrations"))
);

// builder.Services.AddDataProtection();

//alt2
// builder.Services.Configure<ConnectionStrings>(
//     builder.Configuration.GetSection(ConnectionStrings.SectionName)
// );

//alt1
// IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// ConnectionStrings? connectionStrings = config
//     .GetSection("ConnectionStrings")
//     .Get<ConnectionStrings>();

// var defaultConnection = connectionStrings?.DefaultConnection;

//after
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
