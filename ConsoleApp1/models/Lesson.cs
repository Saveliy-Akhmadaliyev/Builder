using System.ComponentModel.DataAnnotations;

namespace Простое_расписние.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Year { get; set; }
    }
}
