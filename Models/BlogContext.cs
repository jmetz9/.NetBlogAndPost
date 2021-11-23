using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogsAndPosts
{
    class BlogContext : DbContext
    {
        DbSet<Blog> Blogs {get; set;}
        DbSet<Post> Posts {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

                configuration.GetSection("ConnectionStrings");

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BloggingContext"));
        }
    }
}