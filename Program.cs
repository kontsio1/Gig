using GigApp.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Host=my_host;Username=my_user;Password=my_pw;Database=my_db";

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddDbContext<ApplicationDbContext>();
// builder.Services.AddDataProtection();
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmnetVariables()
    .Build()


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
