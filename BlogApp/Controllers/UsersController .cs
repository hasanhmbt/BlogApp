using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UsersController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var usersQuery = _unitOfWork.Users.GetAll()
                .OrderBy(u => u.FirstName);

            int totalUsers = usersQuery.Count();
            int totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            var users = usersQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(users);
        }

        public IActionResult Details(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user, IFormFile? ProfileImage)
        {
            if (id != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var originalUser = _unitOfWork.Users.GetById(id);
                if (originalUser == null)
                    return NotFound();

                originalUser.FirstName = user.FirstName;
                originalUser.LastName = user.LastName;
                originalUser.JobTitle = user.JobTitle;
                originalUser.Specialty = user.Specialty;
                originalUser.ScientificFacts = user.ScientificFacts;
                originalUser.Email = user.Email;

                if (ProfileImage != null && ProfileImage.Length > 0)
                {
                    if (!string.IsNullOrEmpty(originalUser.ProfileImageUrl))
                    {
                        var oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, originalUser.ProfileImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (System.IO.File.Exists(oldFilePath))
                            System.IO.File.Delete(oldFilePath);
                    }

                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images", "users");
                    Directory.CreateDirectory(uploadsFolder);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ProfileImage.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ProfileImage.CopyTo(stream);
                    }

                    originalUser.ProfileImageUrl = "/images/users/" + fileName;
                }
                else
                {
                    // No new image provided, keep the old one
                    // originalUser.ProfileImageUrl remains unchanged
                }

                _unitOfWork.Users.Update(originalUser);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Details), new { id = originalUser.Id });
            }
            return View(user);
        }

    }
}
