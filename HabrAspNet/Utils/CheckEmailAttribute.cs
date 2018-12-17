using HabrAspNet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HabrAspNet.Utils
{
    public class CheckEmailAttribute : ValidationAttribute
    {
        private bool isExist;

        public CheckEmailAttribute(bool isExist)
        {
            this.isExist = isExist;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IUserService userService = (IUserService)validationContext.GetService(typeof(IUserService));

            if (userService.CheckEmail(value.ToString()) != isExist)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}