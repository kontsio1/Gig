using GigApp.Models;
using GigApp.Models.Users;
using GigApp.Views.UserAdd;
using GigApp.Views.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger, IMediator mediator) : ControllerBase
{
    [HttpPost(Name = "SignUp")]
    public async Task<IResult> SignUp(UserAddRequest request)
    {
        var response = await mediator.Send(request);
        logger.LogInformation("Sign up user: ${email}", request.Email);
        return response.Succeeded ? Results.Ok() : Results.BadRequest();
    }

    [HttpPost(Name = "Login")]
    public async Task<IResult> Login(UserLoginRequest request)
    {
        var response = await mediator.Send(request);
        logger.LogInformation("Login user: ${email}", request.Email);
        return response.Succeeded ? Results.Ok() : Results.BadRequest();
    }
}
