using MediatR;

namespace GigApp.Views.Gigs;

public class GigsGetRequest() : IRequest<GigDto[]>
{
    public DateTimeOffset? Date { get; set; }
    public string? Location { get; set; }
    public int? Radius { get; set; }
}
