using Microsoft.Extensions.Configuration;
using System.Text;

namespace RegisterLoginJWT.Data.Settings
{
    public static class JWTConfiguration
    {
        public static string BuildConnectionString(IConfiguration configuration)
        {
            DatabaseSettings dbSettings = new DatabaseSettings();
            configuration.Bind("SqlServerConnection", dbSettings);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Server={dbSettings.Server};");
            sb.Append($"Database={dbSettings.Database};");
            sb.Append($"User Id={dbSettings.UserId};");
            sb.Append($"Password={dbSettings.Password};");
            sb.Append($"Trusted_Connection={dbSettings.TrustedConnection};");
            sb.Append($"TrustServerCertificate={dbSettings.TrustServerCertificate};");

            return sb.ToString();
        }
    }
}
