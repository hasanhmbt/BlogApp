using BlogApp.Models;
using BlogApp.Repositories;  
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.Controllers
{
    public class SiteSubjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SiteSubjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var subjects = _unitOfWork.Subjects.GetAll()
                .OrderBy(s => s.Name)
                .ToList();
            return View(subjects);
        }
    }
}
