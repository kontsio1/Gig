using GigApp.Views.Gigs;

namespace GigApp.Models.Gigs;

public interface IGigRepository
{
    Task<Result> AddNewGig(GigAddRequest request);
    Task<GigDto[]> GetGigs(GigsGetRequest request);
}
