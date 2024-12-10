using AutoMapper;
using blog.core.Entities;
using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Automapper
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            #region Roles
            CreateMap<Role, RoleViewModel>();
            #endregion

            #region Users
            CreateMap<UserCreateViewModel, User>();
            CreateMap<User, UserViewModel>();
            #endregion

            #region Blog Post
            CreateMap<BlogPost, BlogPostViewModel>();
            CreateMap<BlogPostCreateViewModel, BlogPost>();
            CreateMap<BlogPostEditViewModel, BlogPost>();
            CreateMap<BlogPostChangeStatusViewModel, BlogPost>();
            CreateMap<BlogPost, BlogPostDetailsViewModel>();
            #endregion
        }
    }
}
