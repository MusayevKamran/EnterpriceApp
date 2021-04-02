using App.Admin.Controllers;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Authorize]
    public class CategoryController : BaseController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_categoryAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CategoryViewModel = _categoryAppService.GetById(id.Value);

            if (CategoryViewModel == null)
            {
                return NotFound();
            }

            return View(CategoryViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "CanWriteCategoryData")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWriteCategoryData")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return View(categoryViewModel);
            //categoryViewModel.CategoryId = Guid.NewGuid();

            _categoryAppService.Create(categoryViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Category Created!";

            return View(categoryViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanWriteCategoryData")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = _categoryAppService.GetById(id.Value);

            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "CanWriteCategoryData")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return View(categoryViewModel);

            _categoryAppService.Update(categoryViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Category Updated!";

            return View(categoryViewModel);
        }

        [HttpGet]
        //[Authorize(Policy = "CanRemoveCategoryData")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryViewModel = _categoryAppService.GetById(id.Value);

            if (categoryViewModel == null)
            {
                return NotFound();
            }

            return View(categoryViewModel);
        }

        [HttpPost, ActionName("Delete")]
        //[Authorize(Policy = "CanRemoveCategoryData")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryAppService.Remove(id);

            if (!IsValidOperation()) return View(_categoryAppService.GetById(id));

            ViewBag.Sucesso = "Category Removed!";
            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public IActionResult History(int id)
        {
            var categoryHistoryData = _categoryAppService.GetAllHistory(id);
            return new ObjectResult(categoryHistoryData);
        }
    }
}
