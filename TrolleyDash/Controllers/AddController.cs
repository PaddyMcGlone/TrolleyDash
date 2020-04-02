using System;
using Microsoft.AspNetCore.Mvc;
using TrolleyDash.Models;
using TrolleyDash.Services;

namespace TrolleyDash.Controllers
{
    public class AddController : Controller
    {
        #region Fields
        private readonly IGroceryService groceryService;
        #endregion

        #region Constructor
        public AddController(IGroceryService groceryService)
        {
            this.groceryService = groceryService;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var groceries = groceryService.GetAllGroceriesToBeFetched();
            var viewModel = new AddViewModel { Groceries = groceries };

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public IActionResult AddGrocery(Grocery grocery)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            groceryService.Add(grocery);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public IActionResult MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("Index");

            groceryService.MarkDone(id);

            return RedirectToAction("Index");
        }

        #endregion
    }
}