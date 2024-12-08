using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogApp.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var subjectsQuery = _unitOfWork.Subjects.GetAll()
                .OrderBy(s => s.Name);

            int totalSubjects = subjectsQuery.Count();
            int totalPages = (int)Math.Ceiling((double)totalSubjects / pageSize);

            var subjects = subjectsQuery
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(subjects);
        }

        public IActionResult Details(int id)
        {
            var subject = _unitOfWork.Subjects.GetById(id);
            if (subject == null)
                return NotFound();
            return View(subject);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subjects.Add(subject);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        public IActionResult Edit(int id)
        {
            var subject = _unitOfWork.Subjects.GetById(id);
            if (subject == null)
                return NotFound();
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Subject subject)
        {
            if (id != subject.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.Subjects.Update(subject);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var subject = _unitOfWork.Subjects.GetById(id);
            if (subject != null)
            {
                _unitOfWork.Subjects.Remove(subject);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
