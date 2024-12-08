 
using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FilesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var filesQuery = _unitOfWork.DownloadFiles.GetAll()
                .OrderByDescending(f => f.UploadDate);

            int totalFiles = filesQuery.Count();
            int totalPages = (int)Math.Ceiling((double)totalFiles / pageSize);

            var files = filesQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(files);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "files");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var downloadFile = new DownloadFiles
                {
                    Name = fileName,
                    FilePath = "/files/" + fileName,
                    FileType = Path.GetExtension(fileName),
                    UploadDate = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                _unitOfWork.DownloadFiles.Add(downloadFile);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Please select a file to upload.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var file = _unitOfWork.DownloadFiles.GetById(id);
            if (file != null)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, file.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                _unitOfWork.DownloadFiles.Remove(file);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
