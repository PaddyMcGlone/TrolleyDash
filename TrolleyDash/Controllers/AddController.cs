using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrolleyDash.Models;
using TrolleyDash.Services;

namespace TrolleyDash.Controllers
{
    [Authorize]
    public class AddController : Controller
    {
        #region Fields
        private readonly IGroceryService GroceryService;
        public UserManager<IdentityUser> UserManager { get; }

        #endregion

        #region Constructor
        public AddController(IGroceryService groceryService,
                             UserManager<IdentityUser> userManager)
        {
            GroceryService = groceryService;
            UserManager = userManager;
        }
        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            // User = lightweight object containing user info
            var currentUser = await UserManager.GetUserAsync(User);

            // Should never be null due to authorize attribute
            if (currentUser == null)
                return Challenge();

            // Retrieve Groceries Async
            var groceries = await GroceryService.GetAllGroceriesToBeFetchedAsync(currentUser);

            if (groceries == null)
                return BadRequest("Could not retrieve Groceries");

            var viewModel = new AddViewModel { Groceries = groceries };
            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGrocery(Grocery grocery)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var currentUser = await UserManager.GetUserAsync(User);
            var AddGrocery = await GroceryService.Add(grocery, currentUser);

            if (!AddGrocery)
                return BadRequest("Could not add Grocery");

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("Index");

            var currentUser = await UserManager.GetUserAsync(User);
            var MarkedGrocery = await GroceryService.MarkDone(id, currentUser);

            if (!MarkedGrocery)
                return BadRequest("Could not mark grocery as done.");

            return RedirectToAction("Index");
        }

        #endregion
    }
}