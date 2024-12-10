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
    public class UserManagementService : IUserManagementService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserManagementService(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserCreateViewModel> CreateUser(UserCreateViewModel model)
        {
            try
            {
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
    }
}
