using AutoMapper;
using blog.core.Entities;
using blog.core.Interface.IRepository;
using blog.core.Interface.IService.IUserService;
using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Service.UserService
{
    public class UserRetrievalService : IUserRetrievalService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserRetrievalService(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserListViewModel> GetAllUsers()
        {
            var model = new UserListViewModel();
            try
            {
                var users = await _userRepository.GetAll();
                model.Data = users
                    .Select(n => _mapper.Map<User, UserViewModel>(n))
                    .ToList();
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode= 500;
                model.Message= e.Message;
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
                    model.Success = true;
                }
                else
                {
                    model.Message = "Invalid username or password.";
                }
                model.Success = true;
            }
            catch (Exception e)
            {
                model.StatusCode = 500;
                model.Message = e.Message;
            }
            return model;
        }

        public async Task<CurrentLoggedinUserViewModel> GetCurrentLoggedInUser(int id)
        {
            var model = new CurrentLoggedinUserViewModel();
            try
            {
                model = _mapper.Map<User, CurrentLoggedinUserViewModel>(await _userRepository.FindById(id));
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
