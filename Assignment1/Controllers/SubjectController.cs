using Microsoft.AspNetCore.Mvc;

namespace CourseBudd.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            var subjects = new List<CourseBudd.Models.Subject>();
            return View(subjects);
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
