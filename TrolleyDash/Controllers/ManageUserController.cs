using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TrolleyDash.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUserController : Controller
    {
        #region Properties
        private readonly UserManager<IdentityUser> _userManager;
        #endregion

        #region Constructor
        public ManageUserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
                .GetUsersInRoleAsync("Administrator"))
                .ToArray();

            var everyone = await _userManager.Users.ToArrayAsync();

            var viewModel = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(viewModel);
        }


        #endregion

    }
}