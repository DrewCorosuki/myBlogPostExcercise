using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static blog.core.Enums.BlogPostEnum;

namespace blog.core.ViewModels
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string BannerImage { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public BlogPostStatus Status { get; set; }
        public int PostedByUserId { get; set; }
        public string PostedByName { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public bool IsDeleted { get; set; }
        public int DeletedByUserId { get; set; }
        public string DeletedByName { get; set; } = string.Empty;
        public DateTime DateDeleted { get; set; }
    }
}
