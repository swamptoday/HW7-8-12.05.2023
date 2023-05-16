using YourFinances.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourFinances.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourFinances.Controllers
{
    public class TransactionController : Controller
    {

        private readonly DataManager dataManager;

        public TransactionController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        // GET: TransactionController
        public ActionResult Index()
        {
            IQueryable<Transaction> model = dataManager.Transactions.GetTransactionsWithCategories();
            return View(model);
        }


        public IActionResult Edit(int id)
        {

            var entity = id == default ? new Transaction() : dataManager.Transactions.GetTransactionById(id);
            ViewBag.CategoryId = new SelectList(dataManager.Categories.GetCategories(), "category_id", "name", entity.category_id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Transaction model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Transactions.SaveTransaction(model);
                return RedirectToAction("Index", "Transaction");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            dataManager.Transactions.DeleteTransaction(id);
            return RedirectToAction("Index", "Transaction");
        }
    }
}
