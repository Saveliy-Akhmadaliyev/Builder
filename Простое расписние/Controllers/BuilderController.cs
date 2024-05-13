using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;

namespace Простое_расписание.Controllers
{
    public class BuilderController : Controller
    {

        private readonly Простое_расписниеContext _context;

        public BuilderController(Простое_расписниеContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string speciality, int year)
        {
            if (_context.Lesson == null)
            {
                return Problem("Entity set 'LessonContext'  is null.");
            }

            var lessons = from m in _context.Lesson
                         select m;

            var ats = from m in _context.AT
                        select m;

            if (!String.IsNullOrEmpty(speciality))
            {
                lessons = lessons.Where(s => s.Speciality!.Contains(speciality) && s.Year == year);
                ats = ats.Where(s => lessons.Select(s => s.Name).Contains(s.Lesson));
            }

            return View(await ats.ToListAsync());
        }
    }
}
