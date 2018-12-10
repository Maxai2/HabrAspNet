using HabrAspNet.Services;
using HabrAspNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult All()
        {
            var posts = postService.GetPosts();

            //PostViewModel postViewModel = new PostViewModel()
            //{
            //    Posts = posts;
            //}

            return View(posts);
        }
    }
}
