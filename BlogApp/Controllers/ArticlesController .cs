using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArticlesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var articlesQuery = _unitOfWork.Articles.GetAll()
                .OrderByDescending(a => a.PublicationDate);

            int totalArticles = articlesQuery.Count();
            int totalPages = (int)Math.Ceiling((double)totalArticles / pageSize);

            var articles = articlesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = _unitOfWork.Articles.GetById(id);
            if (article == null)
                return NotFound();
            return View(article);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article article, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "articles");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    article.FilePath = "/images/articles/" + fileName;
                }

                _unitOfWork.Articles.Add(article);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        public IActionResult Edit(int id)
        {
            var article = _unitOfWork.Articles.GetById(id);
            if (article == null)
                return NotFound();
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Article article, IFormFile? ImageFile)
        {
            if (id != article.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(article.FilePath))
                    {
                        var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, article.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);
                    }

                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "articles");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImageFile.CopyTo(stream);
                    }

                    article.FilePath = "/images/articles/" + fileName;
                }

                _unitOfWork.Articles.Update(article);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var article = _unitOfWork.Articles.GetById(id);
            if (article != null)
            {
                if (!string.IsNullOrEmpty(article.FilePath))
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, article.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }

                _unitOfWork.Articles.Remove(article);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
