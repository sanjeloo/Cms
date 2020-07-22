using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Manage.Users
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
            EditUser = new EditUserViewModel();
        }
        public IEnumerable< UserViewModel> userViewModel { get; set; }
        public EditUserViewModel EditUser { get; set; }
    }
}
