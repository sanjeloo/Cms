﻿using Entities.Entities.Articles;
using Entities.Entities.News;
using Entities.Entities.NewsLetters;
using Entities.Entities.Products;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ApplicationContext : IdentityDbContext<Users>
    {
        public DbSet<tbl_News> News { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<NewsLetter> NewsLetter { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
