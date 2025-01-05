using GigApp.Models;
using MediatR;

namespace GigApp.Views.UserLogin;

public class UserLoginRequest : IRequest<Result>
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
