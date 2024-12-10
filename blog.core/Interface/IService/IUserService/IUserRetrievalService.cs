using blog.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.core.Interface.IService.IUserService
{
    public interface IUserRetrievalService
    {
        Task<UserListViewModel> GetAllUsers();
        Task<CurrentLoggedinUserViewModel> GetCurrentLoggedInUser(int id);
        
    }
}
