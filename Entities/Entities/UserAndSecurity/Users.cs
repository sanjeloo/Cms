using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities.UserAndSecurity
{
    public class Users :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public int Gender { get; set; }
        public bool Availability { get; set; }
    }
}
