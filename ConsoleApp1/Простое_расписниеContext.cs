using Microsoft.EntityFrameworkCore;


namespace Простое_расписние.Data
{
    public class Простое_расписниеContext : DbContext
    {
        public Простое_расписниеContext (DbContextOptions<Простое_расписниеContext> options)
            : base(options)
        {
        }

        public DbSet<Простое_расписние.Models.AT> AT { get; set; } = default!;
        public DbSet<Простое_расписние.Models.Lesson> Lesson { get; set; } = default!;
        public DbSet<Простое_расписние.Models.Teacher> Teacher { get; set; } = default!;
    }
}
