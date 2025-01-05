using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GigApp.Models.Configuration;
using GigApp.Models.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// namespace GigApp.Views;

// public class JwtService
// {
//     private readonly JwtSettings _jwtSettings;

//     public JwtService(IOptions<JwtSettings> jwtSettings)
//     {
//         _jwtSettings = jwtSettings.Value;
//     }

//     public string GenerateToken(User user)
//     {
//         var claims = new[]
//         {
//             // new Claim(ClaimTypes.NameIdentifier, user.Id),
//             // new Claim(ClaimTypes.Name, user.UserName),
//             new Claim(ClaimTypes.Email, user.Email),
//         };

//         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
//         var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//         var token = new JwtSecurityToken(
//             issuer: _jwtSettings.Issuer,
//             audience: _jwtSettings.Audience,
//             claims: claims,
//             expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
//             signingCredentials: creds
//         );

//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }
