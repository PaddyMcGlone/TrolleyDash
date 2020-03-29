using System;
using Microsoft.AspNetCore.Mvc;

namespace TrolleyDash.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}