﻿using blog.core.Entities;
using Microsoft.AspNetCore.Http;
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
        public int UpdatedByUserId { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public int DeletedByUserId { get; set; }
        public string DeletedByName { get; set; } = string.Empty;
        public DateTime DateDeleted { get; set; }
    }
    public class BlogPostListViewModel : ServiceResponseViewModel<BlogPostViewModel> { }

    public class BlogPostCreateViewModel : ServiceResponseSingleItemViewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IFormFile BannerFile { get; set; }
        public string BannerImage { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public BlogPostStatus Status { get; set; }
        public int PostedByUserId { get; set; }
        public string PostedByName { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }

    public class BlogPostEditViewModel : ServiceResponseSingleItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IFormFile BannerFile { get; set; }
        public string BannerImage { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int UpdatedByUserId { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
    public class BlogPostChangeStatusViewModel : ServiceResponseSingleItemViewModel
    {
        public int Id { get; set; }
        public BlogPostStatus Status { get; set; }
    }

    public class BlogPostDetailsViewModel : ServiceResponseSingleItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string BannerImage { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public BlogPostStatus Status { get; set; }
        public int PostedByUserId { get; set; }
        public string PostedByName { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; }
        public int UpdatedByUserId { get; set; }
        public string UpdatedByName { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; }
        public int DeletedByUserId { get; set; }
        public string DeletedByName { get; set; } = string.Empty;
        public DateTime DateDeleted { get; set; }
    }

}
