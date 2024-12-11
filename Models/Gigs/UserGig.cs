using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigApp.Models;

public class UserGig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public string UserId { get; set; } = null!;
    [ForeignKey("Gig")]
    public string GigId { get; set; } = null!;
}