using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Простое_расписние.Data;
using Простое_расписние.Models;

namespace Простое_расписание.Controllers
{
    public class BuilderController : Controller
    {
        private string Speciality { get; set; }
        private int Year { get; set; }

        private string[] MyATVM { get; set; }
        private List<string> Track { get; set; }


        private readonly Простое_расписниеContext _context;

        public BuilderController(Простое_расписниеContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string[] myLessonVM, 
            List<string> myTrackVM, 
            string[] myATVM, 
            string speciality, 
            int year, 
            bool bool1,
            List<int> time
        )
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

            if (!string.IsNullOrEmpty(speciality) && year != 0)
            {
                Speciality = speciality;
                Year = year;
            }

            if (!time.IsNullOrEmpty())
            {
                for (var i = 0; i < 6; i++)
                    time.Add(i * 9 + 1);
            }
            

            var myLessons = lessons.Where(s => s.Speciality!.Contains(Speciality + $"({Year})"));
            var myAts = ats.Where(s => myLessons.Any(p => s.Name.Contains(p.Name)));

            if (!string.IsNullOrEmpty(Speciality) && Year > 0 && Year < 6)
            {
                lessonQuery = myAts.Select(p => p.Lesson);
            }
            else 
            {
                lessonQuery = from m in _context.Lesson
                              orderby m.Name
                              select m.Name;
            }

            if (!(myLessonVM.IsNullOrEmpty()))
            {
                myAts = myAts.Where(s => myLessonVM.Contains(s.Lesson));
                if (MyATVM.IsNullOrEmpty() && Track.IsNullOrEmpty())
                    (MyATVM, Track) = FindATAndTrack(myAts);
            }

            if (myTrackVM.Count > 1)
                myAts = myAts.Where(p => myTrackVM.Any(s => p.Name.Contains(s)));

            if (!time.IsNullOrEmpty())
            {
                myAts = GetGoodAt(myAts, time);
                //if (myLessonVM.Any(p => !myAts.Select(s => s.Lesson).Contains(p)))
                //    return View("С данными настройками расписание не возможно");
            }

            //foreach(var lesson in myLessonVM)
            //{
            //    var main = myAts.Where(p => p.Lesson == lesson).FirstOrDefault();

            //}

            var ATLessonVM = new ATLessonViewModel
            {
                Lesson = new SelectList(await lessonQuery.Distinct().ToListAsync()),
                Subjects = await myAts.ToListAsync(),
                Speciality = speciality,
                Year = year,
                MyLessonVM = myLessonVM,
                MyATVM = MyATVM,
                Track = Track,
                Bool1 = bool1,
                DistinctSubject = new List<string>(),
                MyTrackVM = myTrackVM,
                Time = time
            }; 

            return View(ATLessonVM);
        }

        public (string[], List<string>) FindATAndTrack(IQueryable<AT> aTs)
        {
            var result1 = new List<string>();
            var result2 = new List<string>();
            foreach (var aT in aTs)
            {
                var e = aT.Name.Split(';');
                result1.Add(e.First());
                result2.Add(e.Last());

            }
            return (result1.ToArray(), result2.Distinct().ToList());
        }

        public List<string> MyDistinct(IQueryable<AT> ats)
        {
            var result = new List<string>();
            foreach (var at in ats)
            {
                if (!result.Contains(at.Name))
                    result.Add(at.Name);
            }
            return result;
        }

        public IQueryable<AT> GetGoodAt(IQueryable<AT> aTs, List<int> time)
        {
            var badAT = aTs
                .Where(s=> time.Contains(s.Number))
                .Select(p => p.Name)
                .Distinct();
            return aTs.Where(p => !badAT.Contains(p.Name));
        }
    }
}
