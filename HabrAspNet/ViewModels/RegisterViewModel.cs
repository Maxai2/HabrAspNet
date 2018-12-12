﻿using HabrAspNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login is required")]
        [MaxLength(20)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password must be equal with password")]
        [MaxLength(20)]
        [MinLength(8)]
        public string PasswordReapeat { get; set; }
    }
}
