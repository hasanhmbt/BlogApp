using BlogApp.Models;
using BlogApp.Repositories;  
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.Controllers
{
    public class SiteArticlesController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public SiteArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var articles = _articleRepository.GetAll()
                .OrderByDescending(a => a.PublicationDate)
                .ToList();

            return View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
                return NotFound();

            return View(article);
        }
    }
}
