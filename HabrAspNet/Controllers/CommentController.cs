﻿using HabrAspNet.Models;
using HabrAspNet.Services;
using HabrAspNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService commentService;
        private IUserService userService;
        private IPostService postService;

        public CommentController(ICommentService commentService, IUserService userService, IPostService postService)
        {
            this.commentService = commentService;
            this.userService = userService;
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody]CommentViewModel model)
        {
            if (model.Comment == null)
                return View(model);

            var comment = new Comment()
            {
                CommentDate = DateTime.Now,
                CommentText = model.Comment,
                User = userService.GetUsers().Find(u => u.Id == Int32.Parse(Request.Cookies["id"]))
            };

            postService.GetPost(model.PostId).Comments.Add(comment);
            commentService.AddComment(comment);

            return PartialView("_CommentPartial", comment);
        }
    }
}