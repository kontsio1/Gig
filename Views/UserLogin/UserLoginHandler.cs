using System.Security.Claims;
using GigApp.Models;
using GigApp.Models.Gigs;
using GigApp.Models.Users;
using MediatR;

namespace GigApp.Views.UserLogin;

public class UserLoginHandler(IUserRepository userRepository)
    : IRequestHandler<UserLoginRequest, Result>
{
    public async Task<Result> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetUserByEmail(request.Email);
        if (user.Password == request.Password)
        {
            // var token = GenerateJwtToken(user);
            return Result.Success();
        }
        else
        {
            return Result.Failure("User email or password is not correct");
        }
    }

    // private string GenerateJwtToken(User user)
    // {
    //     var claims = new[]
    //     {
    //         new Claim(ClaimTypes.NameIdentifier, user.Id),
    //         new Claim(ClaimTypes.Name, user.UserName),
    //     };

    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //     var token = new JwtSecurityToken(
    //         issuer: _configuration["Jwt:Issuer"],
    //         audience: _configuration["Jwt:Audience"],
    //         claims: claims,
    //         expires: DateTime.Now.AddDays(1),
    //         signingCredentials: creds
    //     );

    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}
