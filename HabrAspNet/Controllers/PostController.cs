using HabrAspNet.Services;
using HabrAspNet.ViewModels;
using HabrAspNet.Models;
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
        private IUserService userService;

        public PostController(IPostService postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var posts = postService.GetPosts();

            if (Request.Cookies.Count != 0 && Request.Cookies["id"] != null && Request.Cookies["id"] != "")
            {
                var user = userService.GetUsers().Find(u => u.Id == Int32.Parse(Request.Cookies["id"]));

                if (user != null)
                {
                    ViewData["isAuth"] = true;

                    ViewData["UserAvatar"] = user.Avatar;
                }
            }

            return View(posts);
        }

        [HttpPost]
        public IActionResult AddPost(UserViewModel model)
        {
            int previewLength = model.PostText.Length / 2;
            string preview = model.PostText.Substring(0, previewLength);

            postService.AddPost(new Post()
            {
                PostDate = DateTime.Now,
                PostName = model.PostName,
                PostPreview = preview,
                PostText = model.PostText
            });

            return PartialView("_PostsPartial", postService.GetPosts());
        }
    }
}
