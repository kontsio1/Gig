using GigApp.Models;

var builder = WebApplication.CreateBuilder(args);

// string connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddDbContext<ApplicationDbContext>();

// builder.Services.AddDataProtection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

ConnectionStrings? connectionStrings = config
    .GetSection("ConnectionStrings")
    .Get<ConnectionStrings>();

var defaultConnection = connectionStrings?.DefaultConnection;

app.Run();
