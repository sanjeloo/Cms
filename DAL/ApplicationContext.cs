using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<Users>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
