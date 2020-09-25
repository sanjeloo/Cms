using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ViewModels.Manage.Users.Account
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role","True"),
            new Claim("Edit Role","True"),
            new Claim("Delete Role","True")
        };


    }
}
