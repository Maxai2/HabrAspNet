using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public string PostName { get; set; }
        public string PostText { get; set; }

        public List<Post> UserPosts { get; set; }
    }
}