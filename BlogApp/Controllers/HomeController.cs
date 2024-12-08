using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var latestArticles = _unitOfWork.Articles.GetLatestArticles(6);
            var latestFiles = _unitOfWork.DownloadFiles.GetAll()
                .OrderByDescending(f => f.UploadDate)
                .Take(5)
                .ToList();
            var subjects = _unitOfWork.Subjects.GetAll()
                .OrderBy(s => s.Name)
                .Take(5)
                .ToList();

            var user = _unitOfWork.Users.GetAll().FirstOrDefault();  

            var viewModel = new HomeViewModel
            {
                User = user,
                LatestArticles = latestArticles,
                LatestFiles = latestFiles,
                Subjects = subjects
            };

            return View(viewModel);
        }


    }
}
