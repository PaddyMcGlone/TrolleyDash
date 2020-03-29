using System;
using Microsoft.AspNetCore.Mvc;

namespace TrolleyDash.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            RedirectToAction("Add");
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}