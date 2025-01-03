using System.Reflection;
using System.Text;
using GigApp.Models;
using GigApp.Models.Configuration;
using GigApp.Models.Gigs;
using GigApp.Models.Users;
using GigApp.Views;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static GigApp.Models.Configuration.AmazonSecretsManagerConfigurationProvider;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureDatabaseContext(builder);
        ConfigureServices(builder, builder.Services);
        // var sth = builder.Configuration["DBConnectionString"];
        var app = builder.Build();

        ConfigurePipeline(app);

        app.Run();
    }

    private static void ConfigureServices(
        WebApplicationBuilder builder,
        IServiceCollection services
    )
    {
        services.AddControllers();
        builder.Configuration.AddAmazonSecretsManager(
            "eu-west-2",
            "rds!db-7df55b32-8001-4b69-b8d4-7f54a6c4f7e6"
        );
        services.AddOpenApiDocument();
        ConfigureMediatR(services);
        ConfigureRepositories(services);
        ConfigureConfiguration(services, builder);
        ConfigureAuthentication(services, builder);
        services.AddAuthorization();
    }

    private static void ConfigureDatabaseContext(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(
            (_, optionBuilder) =>
            {
                optionBuilder.UseNpgsql(
                    builder.Configuration["DBConnectionString"],
                    x => x.MigrationsHistoryTable("_EfMigrations")
                );
            }
        );
        // builder.Services.AddDataProtection();
    }

    private static void ConfigureMediatR(IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );
    }

    private static void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGigRepository, GigRepository>();
    }

    private static void ConfigureConfiguration(
        IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services.Configure<JwtSettings>(o =>
            builder.Configuration.GetSection(JwtSettings.SectionName).Bind(o)
        );
        builder.Services.Configure<MyCustomSecret>(builder.Configuration);
        // for full view of IConfig providers use appConfig.GetDebugView().ToString();
    }

    private static void ConfigureAuthentication(
        IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtConfig = builder
                    .Configuration.GetSection(JwtSettings.SectionName)
                    .Get<JwtSettings>();

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtConfig.Key)
                    ),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });
    }

    private static void ConfigurePipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }
        //order bellow matters
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}

public static class ConfigurationExtensions
{
    public static void AddAmazonSecretsManager(
        this IConfigurationBuilder configurationBuilder,
        string region,
        string secretName
    )
    {
        var configurationSource = new AmazonSecretsManagerConfigurationSource(region, secretName);
        configurationBuilder.Add(configurationSource);
    }
}
