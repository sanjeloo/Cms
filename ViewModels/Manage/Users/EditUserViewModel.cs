using System.ComponentModel.DataAnnotations;

namespace ViewModels.Manage.Users
{
    public class EditUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "الزامی")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "الزامی")]
        public string PhoneNumber { get; set; }
       
        public int Gender { get; set; }
    }
}
