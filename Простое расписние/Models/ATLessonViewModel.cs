using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Простое_расписние.Models
{
    public class ATLessonViewModel
    {
        public List<AT>? Subjects { get; set; }
        public SelectList? Lesson { get; set; }
        public string? MyLesson { get; set; }
        public string? SearchString { get; set; }
    }
}
