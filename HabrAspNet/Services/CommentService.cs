using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HabrAspNet.Models;

namespace HabrAspNet.Services
{
    public class CommentService : ICommentService
    {
        private HabrContext context;

        public CommentService(HabrContext context)
        {
            this.context = context;
        }

        public Comment AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();

            return comment;
        }

        public List<Comment> GetComments()
        {
            return context.Comments.ToList();
        }
    }
}
