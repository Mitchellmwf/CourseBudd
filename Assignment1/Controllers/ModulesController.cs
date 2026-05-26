using CourseBudd.Data;
using CourseBudd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Use include to load the needed subject data to show the subject name via Eager Loading https://stackoverflow.com/questions/40409133/entity-framework-include-single-object-from-one-to-many-relationship
            var modules = _context.Module.Include(m => m.Subject).OrderBy(m => m.Subject.Name).ThenBy(m => m.Name).ToList();
            return View(modules);
        }
        public IActionResult Create()
        {
            // fetch subjects for dropdown in the view
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
        public IActionResult Edit(int id)
        {
            // fetch subjects for dropdown in the view
            ViewBag.SubjectId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Subject.OrderBy(s => s.Name).ToList(), "SubjectId", "Name");
            // find module to edit
            var module = _context.Module.Find(id);

            if (module == null)
            {
                return NotFound();
            }

            return View(module);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ModuleId, Name, Description, SubjectId")] Module module)
        {
            if (!ModelState.IsValid)
            {
                return View(module);
            }
            // update and save
            _context.Module.Update(module);
            _context.SaveChanges();
            // redirect
            return RedirectToAction(nameof(Index));
        }
    public IActionResult Delete(int id)
        {
            // find module to delete
            var module = _context.Module.Find(id);

            if (module == null)
            {
                return NotFound();
            }
            _context.Module.Remove(module);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}