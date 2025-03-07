using MedicalAppointment.Domain.SecurityInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalAppointment.Infraestructure.Security
{
    public class JwtService(IConfiguration configuration) : IJwtService
    {
        private readonly string _key = configuration["Jwt:key"]!;

        public string GenerateJwt(string firstName, string email, string role)
        {
            //Create user information for token
            Claim[] claims =
            [
                new Claim(ClaimTypes.Name, firstName),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            ];

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Create token details
            JwtSecurityToken jwtConfig = new(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(40),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
