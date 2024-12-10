using AutoMapper;
using blog.core.Entities;
using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IBlogPostService;
using blog.core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Service.BlogPostService
{
    public class BlogPostManagementService : IBlogPostManagementService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostManagementService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostCreateViewModel> CreateBlogPost(BlogPostCreateViewModel model)
        {
            try
            {
                model.Status = Enums.BlogPostEnum.BlogPostStatus.Draft;
                model.PostedByName = _httpContextAccessor.HttpContext.Session.GetString("loggedInUserFullName");
                model.PostedByUserId = (int)_httpContextAccessor.HttpContext.Session.GetInt32("loggedInUserId");
                var blogPost = await _blogPostRepository.Add(_mapper.Map<BlogPostCreateViewModel, BlogPost>(model));
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }
        public async Task<BlogPostEditViewModel> EditBlogPost(BlogPostEditViewModel model)
        {
            try
            {
                model.UpdatedByName = _httpContextAccessor.HttpContext.Session.GetString("loggedInUserFullName");
                model.UpdatedByUserId = (int)_httpContextAccessor.HttpContext.Session.GetInt32("loggedInUserId");
                var blogPost = await _blogPostRepository.FindById(model.Id);
                model.BannerImage = model.BannerImage != "" ? model.BannerImage : blogPost.BannerImage;
                var updatedBlogPost = await _blogPostRepository.Edit(_mapper.Map(model, blogPost));
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode =500;
                model.Message = e.Message;
            }
            return model;
        }
        public async Task<BlogPostChangeStatusViewModel> ChangeBlogPostStatus(BlogPostChangeStatusViewModel model)
        {
            try
            {
                var blogPost = await _blogPostRepository.FindById(model.Id);
                blogPost.Status = model.Status;
                var updatedBlogPost = await _blogPostRepository.Edit(_mapper.Map(model, blogPost));
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }
    }
}
