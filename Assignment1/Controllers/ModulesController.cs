using Assignment1.Data;
using CourseBudd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Runtime.Intrinsics.Arm;

namespace CourseBudd.Controllers
{
    public class ModulesController : Controller
    {
        // Shared DB conn
        private readonly ApplicationDbContext _context;

        // contructor w/db dependency
        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            // Product list to pass to view
            var modules = new List<Module>();
            return View(modules);
        }
        public IActionResult Create()
        {
            // fetch Subjects for dropdown in the view
            ViewBag.SubjectId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Subject.OrderBy(s => s.Name).ToList(), "SubjectId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ModuleId,Name,Description,SubjectId")] Module module)
        {
            if (!ModelState.IsValid)
            {
                return View(module);
            }
            //create and save
            _context.Module.Add(module);
            _context.SaveChanges();

            //redirect to index after successful creation
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
