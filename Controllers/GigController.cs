using GigApp.Views.Gigs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GigApp.Controllers;

public class GigController(ILogger<GigController> logger, IMediator mediator) : ControllerBase
{
    [HttpPost("NewGig")]
    public async Task<IResult> AddGig([FromBody] GigAddRequest request)
    {
        var response = await mediator.Send(request);
        logger.LogInformation("Sign up user: ${email}", request.UserEmail);
        return response.Succeeded ? Results.Ok() : Results.BadRequest();
    }

    [HttpGet("GetGigs")]
    public async Task<GigDto[]> GetGigs([FromQuery] GigsGetRequest request)
    {
        var response = await mediator.Send(request);
        return response;
    }
}
