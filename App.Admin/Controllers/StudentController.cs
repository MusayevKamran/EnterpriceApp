using System;
using App.Application.Interfaces.Course;
using App.Application.ViewModels.Course;
using App.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize]
    public class StudentController : BaseController
    {
        private readonly IStudentAppService _studentAppService;

        public StudentController(IStudentAppService studentAppService, 
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _studentAppService = studentAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("student-management/list-all")]
        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("student-management/student-details/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StudentViewModel = _studentAppService.GetById(id.Value);

            if (StudentViewModel == null)
            {
                return NotFound();
            }

            return View(StudentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteStudentData")]
        [Route("student-management/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteStudentData")]
        [Route("student-management/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel StudentViewModel)
        {
            if (!ModelState.IsValid) return View(StudentViewModel);
            _studentAppService.Register(StudentViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Student Registered!";

            return View(StudentViewModel);
        }
        
        [HttpGet]
        [Authorize(Policy = "CanWriteStudentData")]
        [Route("student-management/edit-student/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StudentViewModel = _studentAppService.GetById(id.Value);

            if (StudentViewModel == null)
            {
                return NotFound();
            }

            return View(StudentViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteStudentData")]
        [Route("student-management/edit-student/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel StudentViewModel)
        {
            if (!ModelState.IsValid) return View(StudentViewModel);

            _studentAppService.Update(StudentViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Student Updated!";

            return View(StudentViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanRemoveStudentData")]
        [Route("student-management/remove-student/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StudentViewModel = _studentAppService.GetById(id.Value);

            if (StudentViewModel == null)
            {
                return NotFound();
            }

            return View(StudentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Policy = "CanRemoveStudentData")]
        [Route("student-management/remove-student/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _studentAppService.Remove(id);

            if (!IsValidOperation()) return View(_studentAppService.GetById(id));

            ViewBag.Sucesso = "Student Removed!";
            return RedirectToAction("Index");
        }

        //[AllowAnonymous]
        //[Route("student-management/student-history/{id:guid}")]
        //public JsonResult History(Guid id)
        //{
        //    var StudentHistoryData = _studentAppService.GetAllHistory(id);
        //    return Json(StudentHistoryData);
        //}
    }
}
