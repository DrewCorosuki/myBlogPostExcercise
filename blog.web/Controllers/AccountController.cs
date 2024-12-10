using blog.core.Interface.IService.IUserService;
using blog.core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace blog.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        public AccountController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
