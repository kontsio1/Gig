using GigApp.Models.Gigs;
using MediatR;

namespace GigApp.Views.Gigs;

public class GetGigsHandler(IGigRepository gigRepository)
    : IRequestHandler<GigsGetRequest, GigDto[]>
{
    public async Task<GigDto[]> Handle(GigsGetRequest request, CancellationToken cancellationToken)
    {
        return await gigRepository.GetGigs(request);
    }
}
