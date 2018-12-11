using HabrAspNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        [CheckEmail(ErrorMessage = "User is not registered!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
