using GigApp.Models;
using MediatR;

namespace GigApp.Views.Gigs;

public class GigAddRequest : IRequest<Result>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    public string? UserEmail { get; set; }
}
