using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.Controllers
{
    public class SiteFilesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SiteFilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var files = _unitOfWork.DownloadFiles.GetAll()
                .OrderByDescending(f => f.UploadDate)
                .ToList();

            return View(files);
        }
    }
}
