using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Простое_расписние.Models;

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
