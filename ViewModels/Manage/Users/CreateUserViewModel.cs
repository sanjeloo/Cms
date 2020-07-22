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

        [Required(ErrorMessage = "الزامی")]
        //[Remote("CheckUserName", "UserManagers", "Manage")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "الزامی")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "الزامی")]
        public string Password { get; set; }

        [Required(ErrorMessage = "الزامی")]
        public string RepeatPassword { get; set; }
        public int Gender { get; set; }
    }
}
