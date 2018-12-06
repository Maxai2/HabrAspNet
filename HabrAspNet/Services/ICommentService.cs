using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Services
{
    public interface ICommentService
    {
        List<Comment> GetComments();
        Comment AddComment(Comment comment);
    }
}
