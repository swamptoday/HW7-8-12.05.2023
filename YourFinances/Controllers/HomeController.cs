using YourFinances.Domain;
using YourFinances.Models;
using YourFinances.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourFinances.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(int? year, int? month)
        {
            if (!year.HasValue || !month.HasValue)
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
            }

            var selectedMonth = new DateTime(year.Value, month.Value, 1);

            var transactions = dataManager.Transactions.GetTransactionsWithCategories()
                .Where(t => t.date.Month == selectedMonth.Month && t.date.Year == selectedMonth.Year)
                .AsEnumerable()
                .GroupBy(t => t.Category)
                .Select(g => new CategoryViewModel
                {
                    CategoryName = g.Key.name,
                    TotalCost = g.Sum(t => t.cost)
                })
                .ToList();

            var viewModel = new TransactionsViewModel
            {
                Transactions = transactions,
                SelectedMonth = selectedMonth
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
