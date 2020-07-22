using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.UI.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "فیلد {0} الزامی است")]
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "فیلد {0} الزامی است")]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "منو بشناس")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
