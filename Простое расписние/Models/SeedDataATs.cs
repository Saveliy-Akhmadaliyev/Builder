using Microsoft.EntityFrameworkCore;
using Простое_расписние.Data;

namespace Простое_расписние.Models
{
    public static class SeedDataATs
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Простое_расписниеContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Простое_расписниеContext>>()))
            {
                // Look for any movies.
                if (context.AT.Any())
                {
                    return;   // DB has been seeded
                }
                context.AT.AddRange(
                    new AT
                    {
                        Name = "АТ00",
                        Lesson = "Музыка",
                        Lector = "Шишло",
                        Mentor = "Лянников",
                        Place = "Коминтерна 5",
                        Number = 1,
                        IsOnline = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
