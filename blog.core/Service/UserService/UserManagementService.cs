using AutoMapper;
using blog.core.Entities;
using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IUserService;
using blog.core.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Service.UserService
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserManagementService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<UserCreateViewModel> CreateUser(UserCreateViewModel model)
        {
            try
            {
                var role = await _roleRepository.FindById(model.RoleId);
                model.RoleName = role.Name;
                var user = await _userRepository.Add(_mapper.Map<UserCreateViewModel, User>(model));
                model.Id = user.Id;
                
                model.Message = "User has been created successfully.";
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }

        public async Task<UserDeleteViewModel> DeleteUser(UserDeleteViewModel model)
        {
            try
            {
                var user = await _userRepository.FindById(model.Id);
                user.IsDeleted = true;
                await _userRepository.SoftDelete(user);
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }

        public async Task<LogInViewModel> LogIn(LogInViewModel model)
        {
            try
            {
                var user = await _userRepository.Get(i => i.UserName == model.UserName && i.Password == model.Password);
                if (user != null)
                {
                    var u = user.FirstOrDefault();
                    if (u.IsDeleted)
                    {
                        model.Message = "Invalid username or password.";
                    }
                    else
                    {
                        _httpContextAccessor.HttpContext.Session.SetInt32("loggedInUserId", u.Id);
                        _httpContextAccessor.HttpContext.Session.SetString("loggedInUserFullName", u.FullName);
                        _httpContextAccessor.HttpContext.Session.SetString("userFirstName", u.FirstName);
                        _httpContextAccessor.HttpContext.Session.SetInt32("RoleId", u.RoleId);
                        model.Success = true;
                    }
                }
                else
                {
                    model.Message = "Invalid username or password.";
                }
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
