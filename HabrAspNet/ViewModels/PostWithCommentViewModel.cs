using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.ViewModels
{
    public class PostWithCommentViewModel
    {
        public Post Post { get; set; }
        public List<Comment> PostComments { get; set; }
        public string Comment { get; set; }
    }
}
