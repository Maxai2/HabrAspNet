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
        private IUserService userService;

        public PostController(IPostService postService, IUserService userService)
        {
            this.postService = postService;
            this.userService = userService;
        }

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
    }
}
