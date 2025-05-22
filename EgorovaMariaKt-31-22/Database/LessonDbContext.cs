using EgorovaMariaKt_31_22.Database.Configurations;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Database
{
    public class LessonDbContext : DbContext
    {


        //таблицы

        DbSet <Lesson> Lessons { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<WorkTime> WorkTimes { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<AcademicDegree> AcademicDegrees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //добавляем конфигурации к таблицам
           modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkTimeConfiguration());

        }

        public LessonDbContext(DbContextOptions<LessonDbContext> options) : base(options)
        {

        }
    }
}
