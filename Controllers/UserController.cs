using GigApp.Models;
using GigApp.Views.UserAdd;
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
        return Results.Ok();
    }
}