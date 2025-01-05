using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GigApp.Models.Users;

namespace GigApp.Models;

public class UserGig
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Gig")]
    public Guid GigId { get; set; }
    public virtual Gig Gig { get; set; }
}
