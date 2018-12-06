using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabrAspNet.Models;

namespace HabrAspNet.Services
{
    public class PostService : IPostService
    {
        private HabrContext context;

        public PostService(HabrContext context)
        {
            this.context = context;
        }

        public Post AddPost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();

            return post;
        }

        public Post GetPost(int id)
        {
            return context.Posts.Find(id);
        }

        public List<Post> GetPosts()
        {
            return context.Posts.ToList();
        }
    }
}
