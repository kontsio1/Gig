using GigApp.Models;
using MediatR;

namespace GigApp.Views.UserAdd;

public class UserAddRequest : IRequest<Result>
{
    public string Email { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}