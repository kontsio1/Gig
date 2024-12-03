using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GigApp.Models
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
    }
}