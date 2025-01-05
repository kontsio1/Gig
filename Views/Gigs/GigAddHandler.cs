using GigApp.Models;
using GigApp.Models.Gigs;
using MediatR;

namespace GigApp.Views.Gigs;

public class GigAddHandler(IGigRepository gigRepository) : IRequestHandler<GigAddRequest, Result>
{
    public async Task<Result> Handle(GigAddRequest request, CancellationToken cancellationToken)
    {
        var response = await gigRepository.AddNewGig(request);
        return response;
    }
}
