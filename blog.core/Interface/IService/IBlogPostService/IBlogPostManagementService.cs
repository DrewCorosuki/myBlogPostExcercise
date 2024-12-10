using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IService.IBlogPostService
{
    public interface IBlogPostManagementService
    {
        Task<BlogPostCreateViewModel> CreateBlogPost(BlogPostCreateViewModel model);
        Task<BlogPostEditViewModel> EditBlogPost(BlogPostEditViewModel model);
        Task<BlogPostChangeStatusViewModel> ChangeBlogPostStatus(BlogPostChangeStatusViewModel model);
    }
}
