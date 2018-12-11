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

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult CheckEmail(string email)
        {
            if (userService.CheckEmail(email))
            {
                return Json(false);
            }

            return Json(true);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
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
                ViewData["isAuth"] = true;
                ViewData["UserAvatar"] = user.Avatar;

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
    }
}
