using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;
using Простое_расписние.Models;

namespace Простое_расписание.Controllers
{
    public class BuilderController : Controller
    {
        private string Speciality { get; set; }
        private int Year { get; set; }


        private readonly Простое_расписниеContext _context;

        public BuilderController(Простое_расписниеContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string myLesson, string speciality, int year)
        {
            if (_context.Lesson == null)
            {
                return Problem("Entity set 'LessonContext' is null.");
            }

            IQueryable<string> lessonQuery;

            var lessons = from m in _context.Lesson
                         select m;

            var ats = from m in _context.AT
                        select m;

            if (!string.IsNullOrEmpty(speciality))
            {
                lessons = lessons.Where(s => s.Speciality!.Contains(speciality) && s.Year == year);
                ats = ats.Where(s => lessons.Select(s => s.Name).Contains(s.Lesson));
                lessonQuery = lessons.Select(s => s.Name);
                Speciality = speciality;
                Year = year;
            }

            if (!string.IsNullOrEmpty(Speciality) && year > 0 && year < 6)
            {
                
                lessonQuery = lessons.Select(s => s.Name);
            }
            else
            {
                lessonQuery = from m in _context.Lesson
                              orderby m.Name
                              select m.Name;
            }

            if (!string.IsNullOrEmpty(myLesson))
            {
                lessonQuery = ats
                    .Where(s => lessons
                        .Select(s => s.Name)
                        .Contains(myLesson))
                    .Select(s => s.Lesson);
                ats = ats.Where(s => s.Lesson == myLesson);
            }
            var ATLessonVM = new ATLessonViewModel
            {
                Lesson = new SelectList(await lessonQuery.Distinct().ToListAsync()),
                Subjects = await ats.ToListAsync()
            };

            return View(ATLessonVM);
        }
    }
}
