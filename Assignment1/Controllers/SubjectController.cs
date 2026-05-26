using CourseBudd.Data;
using CourseBudd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseBudd.Controllers
{
    public class SubjectController : Controller
    {
        //shared db conn
        private readonly ApplicationDbContext _context;

        //Constructor w/dp dependency 
        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var subject = _context.Subject.ToList();
            return View(subject);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("SubjectId,Name,Description")] CourseBudd.Models.Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }
            // Create new subject & save to database
            _context.Subject.Add(subject);
            _context.SaveChanges();

            // Redirect to Index to see update list of categories
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            // find subject to edit
            var subject = _context.Subject.Find(id);

            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("SubjectId, Name, Description")] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return View(subject);
            }
            // Update subject in database
            _context.Subject.Update(subject);
            _context.SaveChanges();
            // Redirect to Index to see update list of subjects
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            // find subject to delete
            var subject = _context.Subject.Find(id);

            if (subject == null)
            {
                return NotFound();
            }
            _context.Subject.Remove(subject);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
