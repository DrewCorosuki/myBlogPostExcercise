﻿using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IService.IBlogPostService
{
    public interface IBlogPostRetrievalService
    {
        Task<BlogPostListViewModel> GetBlogPost();
        Task<BlogPostDetailsViewModel> FindBlogPostById(int id);
    }
}
