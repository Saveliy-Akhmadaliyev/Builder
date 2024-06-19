namespace Простое_расписние.Models
{
    public class AT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lesson { get; set; }
        public string Lector { get; set; }
        public string Mentor { get; set; }
        public int Number { get; set; }
        public string? Place { get; set; }
        public bool IsOnline { get; set; }
    }
}
