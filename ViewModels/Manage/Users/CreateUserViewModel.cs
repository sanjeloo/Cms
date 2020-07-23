using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ViewModels.Manage.Users
{
    public class CreateUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Remote("CheckUserName", "UserManagers", "Manage",HttpMethod ="post")]
        public string UserName { get; set; }

        [MinLength(11,ErrorMessage ="{0}باید حتما 11 رقم باشد")]
        [MaxLength(11,ErrorMessage ="{0}باید حتما 11 رقم باشد")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره تلفن ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [MinLength(6,ErrorMessage ="{0} باید حداقل 6 کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("Password",ErrorMessage ="کلمه عبور و تکرار آن مشابه هم نیستند")]
        public string RepeatPassword { get; set; }
        public int Gender { get; set; }
    }
}
