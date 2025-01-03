using GigApp.Models.Configuration;
using GigApp.Models.Gigs;
using MediatR;
using Microsoft.Extensions.Options;

namespace GigApp.Views.Gigs;

public class GetGigsHandler(IGigRepository gigRepository, IOptions<MyCustomSecret> myCustomScret)
    : IRequestHandler<GigsGetRequest, GigDto[]>
{
    public async Task<GigDto[]> Handle(GigsGetRequest request, CancellationToken cancellationToken)
    {
        var sth = myCustomScret.Value;
        return await gigRepository.GetGigs(request);
    }
}
