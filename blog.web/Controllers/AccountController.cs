using blog.core.Interface.IService.IUserService;
using blog.core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IUserRetrievalService _userRetrievalService;
        public AccountController(IUserManagementService userManagementService, IUserRetrievalService userRetrievalService)
        {
            _userManagementService = userManagementService;
            _userRetrievalService = userRetrievalService;
        }
        public async Task<IActionResult> Index()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if(roleId != 1)
            {
                return RedirectToAction("", "BlogPost");
            }
            return View(await _userRetrievalService.GetAllUsers());
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            var login = await _userManagementService.LogIn(model);
            if (login.Success)
            {
                return RedirectToAction("","BlogPost");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != 1)
            {
                return RedirectToAction("", "BlogPost");
            }
            var user = await _userManagementService.CreateUser(model);
            if (!model.Success)
            {
                return View();
            }
            else
            {
                return RedirectToAction("","Account");
            }
        }

        public async Task<IActionResult> DeleteUser(UserDeleteViewModel model)
        {
            return Json(await _userManagementService.DeleteUser(model));
        }
    }
}
