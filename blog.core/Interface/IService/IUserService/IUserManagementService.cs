using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IService.IUserService
{
    public interface IUserManagementService
    {
        Task<UserCreateViewModel> CreateUser(UserCreateViewModel model);
        Task<UserDeleteViewModel> DeleteUser(UserDeleteViewModel model);
        Task<LogInViewModel> LogIn(LogInViewModel model);
    }
}
