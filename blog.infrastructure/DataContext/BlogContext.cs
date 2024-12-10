using blog.core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.infrastructure.DataContext
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {
            this.Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=blogDb;Integrated Security=false;User ID=sa;pwd=112233";
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get;set; }
    }
}
