using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostName { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string PostPreview { get; set; }

        [Required]
        public string PostText { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}