using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Enums
{
    public class BlogPostEnum
    {
        public enum BlogPostStatus
        {
            Rejected = -1,
            Draft= 0,
            Published = 1,
        }
    }
}
