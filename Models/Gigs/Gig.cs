using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigApp.Models;

public class Gig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public string Address { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
}
