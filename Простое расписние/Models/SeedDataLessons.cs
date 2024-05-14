using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;

namespace Простое_расписние.Models
{
    public class SeedDataLessons
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Простое_расписниеContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Простое_расписниеContext>>()))
            {
                // Look for any movies.
                if (context.Lesson.Any())
                {
                    return;   // DB has been seeded
                }
                context.Lesson.AddRange(
                    new Lesson
                    {
                        Name = "Музыка",
                        Speciality = "НЕТ",
                        Year = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
