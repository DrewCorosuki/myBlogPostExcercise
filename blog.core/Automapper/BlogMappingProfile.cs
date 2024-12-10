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

            #endregion

            #region Users
            CreateMap<UserCreateViewModel, User>();
            #endregion

            #region Blog Post

            #endregion
        }
    }
}
