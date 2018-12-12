using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public string Avatar { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}