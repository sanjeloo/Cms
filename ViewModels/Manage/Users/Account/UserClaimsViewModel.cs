using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Manage.Users.Account
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }
        public string UserId { get; set; }

        public List<UserClaim> Claims { get; set; }
    }
}
