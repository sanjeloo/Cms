using Entities.Entities.Articles;
using Entities.Entities.Products;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<Users>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Product> Product { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
