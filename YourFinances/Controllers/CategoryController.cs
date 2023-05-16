using YourFinances.Domain;
using YourFinances.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace YourFinances.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataManager dataManager;

        public CategoryController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            IQueryable<Category> model = dataManager.Categories.GetCategories();
            return View(model);
        }

        public IActionResult Edit(int id)
        {

            var entity = id == default ? new Category() : dataManager.Categories.GetCategoryById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Categories.SaveCategory(model);
                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            dataManager.Categories.DeleteCategory(id);
            return RedirectToAction("Index", "Category");
        }

    }
}
