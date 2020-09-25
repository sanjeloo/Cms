using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.Manage.Users.Roles
{
    public class CreateRoleViewModel
    {
        [Display(Name ="اسم نقش")]
        [Required(ErrorMessage ="فیلد {0} اجباری است")]
        public string RoleName { get; set; }
    }
}
