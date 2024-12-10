using AutoMapper;
using blog.core.Entities;
using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IBlogPostService;
using blog.core.ViewModels;
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
        private readonly IBlogPostRepository _blogPostRepository;
        public BlogPostManagementService(
            IMapper mapper,
            IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<CreateBlogPostViewModel> CreateBlogPost(CreateBlogPostViewModel model)
        {
            try
            {
                model.Status = Enums.BlogPostEnum.BlogPostStatus.Draft;
                var blogPost = await _blogPostRepository.Add(_mapper.Map<CreateBlogPostViewModel, BlogPost>(model));
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }
        public async Task<EditBlogPostViewModel> EditBlogPost(EditBlogPostViewModel model)
        {
            try
            {
                var blogPost = await _blogPostRepository.FindById(model.Id);
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
    }
}
