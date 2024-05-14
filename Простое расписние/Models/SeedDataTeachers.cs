using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;

namespace Простое_расписние.Models
{
    public class SeedDataTeachers
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Простое_расписниеContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Простое_расписниеContext>>()))
            {
                // Look for any movies.
                if (context.Teacher.Any())
                {
                    return;   // DB has been seeded
                }
                context.Teacher.AddRange(
                    new Teacher
                    {
                        Name = "Шишло",
                        Info = "НЕТ"                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
