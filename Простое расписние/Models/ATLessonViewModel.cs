using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Простое_расписние.Models
{
    public class ATLessonViewModel
    {
        public List<AT>? Subjects { get; set; }
        public SelectList? Lesson { get; set; }
        public List<string>? Track { get; set; }
        public string[]? MyLessonVM { get; set; }
        public string[]? MyATVM { get; set; }
        public List<string>? MyTrackVM { get; set; }
        public string? Speciality { get; set; }
        public int Year { get; set; }
        public bool Bool1 { get; set; }
        public List<string>? DistinctSubject { get; set; }
        public List<int>? Time { get; set; }
    }
}
