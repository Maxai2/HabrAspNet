using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        [Required]
        public string CommentText { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}