using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Manage.Users
{
    public class EditUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       // [Remote("CheckUserName", "UserManagers", "Manage", HttpMethod = "post")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$", ErrorMessage = " فقط کاراکتر های لاتین مجاز است")]
        public string UserName { get; set; }
        [MinLength(11, ErrorMessage = "{0}باید حتما 11 رقم باشد")]
        [MaxLength(11, ErrorMessage = "{0}باید حتما 11 رقم باشد")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره تلفن ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PhoneNumber { get; set; }
       
        public int Gender { get; set; }
    }
}
