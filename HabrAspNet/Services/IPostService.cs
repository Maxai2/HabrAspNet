using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Services
{
    public interface IPostService
    {
        Post AddPost(Post post);
        List<Post> GetPosts();
        Post GetPost(int id);
    }
}
