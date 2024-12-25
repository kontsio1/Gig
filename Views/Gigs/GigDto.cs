namespace GigApp.Views.Gigs;

public class GigDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public string Address { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
}
