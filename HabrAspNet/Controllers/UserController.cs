using HabrAspNet.Models;
using HabrAspNet.Services;
using HabrAspNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private IPostService postService;

        public UserController(IUserService userService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
        }

        //[HttpPost]
        //public IActionResult CheckEmail(string email)
        //{
        //    if (userService.CheckEmail(email))
        //    {
        //        return Json(false);
        //    }

        //    return Json(true);
        //}

        //[HttpPost]
        //public IActionResult CheckLogin(string login)
        //{
        //    if (!userService.CheckLogin(login))
        //    {
        //        return Json(false);
        //    }

        //    return Json(true);
        //}

        [HttpGet]
        public IActionResult GoToProfile()
        {
            var user = new UserViewModel();

            if (Request.Cookies.Count != 0)
            {
                int id = Int32.Parse(Request.Cookies["id"]);

                user.User = userService.GetUsers().Find(u => u.Id == id);

                user.UserPosts = new List<Post>();

                postService.GetPosts().ForEach(p =>
                {
                    if (id == p.Id)
                        user.UserPosts.Add(p);
                });

                ViewData["isAuth"] = true;

                ViewData["UserAvatar"] = user.User.Avatar;
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult GetUser(int id)
        {
            var user = userService.GetUser(id);

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userService.GetUsers().Find(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {

                //cookie
                Response.Cookies.Append("id", user.Id.ToString());

                return RedirectToAction("All", "Post");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Avatar = "/user-default.png",
                Email = model.Email,
                Login = model.Login,
                Password = model.Password,
                RegistrationDate = DateTime.Now
            };

            var userId = userService.AddUser(user).Id;


            //cookie
            Response.Cookies.Append("id", userId.ToString());

            return RedirectToAction("All", "Post");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Append("id", "");

            return RedirectToAction("All", "Post");
        }
    }
}
