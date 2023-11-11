using Microsoft.Extensions.Configuration;
using System.Text;

namespace RegisterLoginJWT.Data.Settings
{
    public static class JWTConfigurationData
    {
        public static string BuildJWTString(IConfiguration configuration)
        {
            JWTSettings jwtSettings = new JWTSettings();
            configuration.Bind("Jwt", jwtSettings);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Secret={jwtSettings.Secret};");
            sb.Append($"Issuer={jwtSettings.Issuer};");
           
            return sb.ToString();
        }
    }
}
