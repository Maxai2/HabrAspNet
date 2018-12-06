using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }

        public virtual User User { get; set; }
    }
}
