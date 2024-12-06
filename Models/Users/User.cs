using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigApp.Models.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Name { get; set; } = null!;
       [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; } = null!;
    }
}