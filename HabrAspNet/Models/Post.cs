using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string PostName { get; set; }
        [Required]
        public DateTime PostDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string PostPreview { get; set; }
        [Required]
        public string PostText { get; set; }

        public int UserId { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}