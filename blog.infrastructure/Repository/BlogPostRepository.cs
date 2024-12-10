using blog.core.Entities;
using blog.core.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.infrastructure.Repository
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
    }
}
