using blog.core.Interface.IService.IBlogPostService;
using blog.core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static blog.core.Enums.BlogPostEnum;

namespace blog.web.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostManagementService _blogPostManagementService;
        private readonly IBlogPostRetrievalService _blogPostRetrievalService;
        public BlogPostController(
            IBlogPostManagementService blogPostManagementService, 
            IBlogPostRetrievalService blogPostRetrievalService)
        {
            _blogPostManagementService = blogPostManagementService;
            _blogPostRetrievalService = blogPostRetrievalService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _blogPostRetrievalService.GetBlogPost());
        }

        public async Task<IActionResult> ChangeBlogPostStatus(BlogPostChangeStatusViewModel model)
        {
            return Json(await _blogPostManagementService.ChangeBlogPostStatus(model));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostCreateViewModel model)
        {
            //save file if file is valid image
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            if (model.BannerFile != null)
            {
                var fileExt = Path.GetExtension(model.BannerFile.FileName);
                if (!Array.Exists(validExtensions, ext => ext == fileExt))
                {
                    ViewBag.ErrorMessage = "Invalid banner file.";
                    return View();
                }
                else
                {
                    //check file size
                    long fileSize = model.BannerFile.Length;
                    double fileSizeInKb = fileSize / 1024.0;
                    double fileSizeInMb = fileSizeInKb / 1024.0;
                    if (fileSizeInMb > 5)
                    {
                        ViewBag.ErrorMessage = "Banner file size exceeds the max file size allowed.";
                        return View();
                    }

                    model.BannerImage = Helpers.FileHelper.SaveFile(model.BannerFile, "wwwroot/content/dist/img/banners/");
                }
            }
            await _blogPostManagementService.CreateBlogPost(model);
            return RedirectToAction("","BlogPost");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _blogPostRetrievalService.FindBlogPostById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogPostEditViewModel model)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            if (model.BannerFile != null)
            {
                var fileExt = Path.GetExtension(model.BannerFile.FileName);
                if (!Array.Exists(validExtensions, ext => ext == fileExt))
                {
                    ViewBag.ErrorMessage = "Invalid banner file.";
                    return View(await _blogPostRetrievalService.FindBlogPostById(model.Id));
                }
                else
                {
                    long fileSize = model.BannerFile.Length;
                    double fileSizeInKb = fileSize / 1024.0;
                    double fileSizeInMb = fileSizeInKb / 1024.0;
                    if (fileSizeInMb > 5)
                    {
                        ViewBag.ErrorMessage = "Banner file size exceeds the max file size allowed.";
                        return View();
                    }
                    model.BannerImage = Helpers.FileHelper.SaveFile(model.BannerFile, "wwwroot/content/dist/img/banners/");
                }
            }
            await _blogPostManagementService.EditBlogPost(model);
            return RedirectToAction("", "BlogPost");
        }
    }
}
