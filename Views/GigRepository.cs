using GigApp.Models;
using GigApp.Models.Gigs;
using GigApp.Views.Gigs;
using Microsoft.EntityFrameworkCore;

namespace GigApp.Views;

public class GigRepository(ApplicationDbContext context) : IGigRepository
{
    public async Task<Result> AddNewGig(GigAddRequest request)
    {
        try
        {
            var newGig = new Gig
            {
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                Date = request.Date,
            };
            context.Gigs.Add(newGig);
            await context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure(e.Message);
        }
    }

    public async Task<GigDto[]> GetGigs(GigsGetRequest request)
    {
        var gigs = await context
            .Gigs.Select(g => new GigDto
            {
                Name = g.Name,
                Description = g.Description,
                Date = g.Date,
                Address = g.Address,
            })
            .ToArrayAsync();
        return gigs;
    }
}
