using Microsoft.AspNetCore.Mvc;

namespace CourseBudd.Controllers
{
    public class ModulesController : Controller
    {
        public IActionResult Index()
        {
            var modules = new List<CourseBudd.Models.Module>();
            return View(modules);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
