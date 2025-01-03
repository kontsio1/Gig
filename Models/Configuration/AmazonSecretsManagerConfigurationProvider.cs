using System.Text.Json;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace GigApp.Models.Configuration;

public class AmazonSecretsManagerConfigurationProvider : ConfigurationProvider
{
    private readonly string _region;
    private readonly string _secretName;

    public AmazonSecretsManagerConfigurationProvider(string region, string secretName)
    {
        _region = region;
        _secretName = secretName;
    }

    public override void Load()
    {
        var secret = GetSecret();

        var secretData = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);

        if (secretData != null)
        {
            Data = secretData;

            // If the secret matches the structure of MyCustomSecret, construct the connection string
            if (secretData.ContainsKey("username") && secretData.ContainsKey("password"))
            {
                string username = secretData["username"];
                string password = secretData["password"];

                string connectionString =
                    $"Host=gig-database.czam44y242j3.eu-west-2.rds.amazonaws.com;Port=5432;Database=postgres;Username={username};Password={password};Trust Server Certificate=true;";

                // Add the constructed connection string to the Data dictionary
                Data["DBConnectionString"] = connectionString;
            }
        }
    }

    private string GetSecret()
    {
        var request = new GetSecretValueRequest
        {
            SecretId = _secretName,
            VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
        };

        using (var client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(_region)))
        {
            var response = client.GetSecretValueAsync(request).Result;

            string secretString;
            if (response.SecretString != null)
            {
                secretString = response.SecretString;
            }
            else
            {
                var memoryStream = response.SecretBinary;
                var reader = new StreamReader(memoryStream);
                secretString = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(reader.ReadToEnd())
                );
            }

            return secretString;
        }
    }
}
