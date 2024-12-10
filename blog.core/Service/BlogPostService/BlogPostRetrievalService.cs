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
    public class BlogPostRetrievalService : IBlogPostRetrievalService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostRetrievalService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper; 
            _httpContextAccessor = httpContextAccessor;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BlogPostListViewModel> GetBlogPost()
        {
            var model = new BlogPostListViewModel();
            try
            {
                var loggedInUserId = _httpContextAccessor.HttpContext.Session.GetInt32("loggedInUserId");
                var userRoleId = _httpContextAccessor.HttpContext.Session.GetInt32("RoleId");
                var blogPosts = userRoleId == 1 ?
                    await _blogPostRepository.GetAll() :
                    await _blogPostRepository.Get(i => i.PostedByUserId == loggedInUserId);
                
                model.Data = blogPosts.Select(n => _mapper.Map<BlogPost, BlogPostViewModel>(n))
                    .OrderByDescending(i => i.DatePosted)
                    .ToList();
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }
        public async Task<BlogPostDetailsViewModel> FindBlogPostById(int id)
        {
            var model = new BlogPostDetailsViewModel();
            try
            {
                model = _mapper.Map<BlogPost, BlogPostDetailsViewModel>(await _blogPostRepository.FindById(id));
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
