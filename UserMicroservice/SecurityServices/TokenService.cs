using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserMicroservice.SecurityServices
{
    public class TokenService
    {
        private readonly SymmetricSecurityKey _signingKey;

        public TokenService(IConfiguration configuration)
        {
            var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey");
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }


        public string GenerateToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Metoden ValidateToken kan implementeres her, hvis nødvendigt
    }
}
