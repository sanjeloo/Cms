using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Manage.Users.Roles
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            UserName = new List<string>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<string> UserName { get; set; }

    }
}
