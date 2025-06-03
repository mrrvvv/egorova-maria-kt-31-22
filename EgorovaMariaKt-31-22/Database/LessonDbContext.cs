using EgorovaMariaKt_31_22.Database.Configurations;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Database
{
    public class LessonDbContext : DbContext
    {


        //таблицы

        public DbSet <Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //добавляем конфигурации к таблицам
           modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkTimeConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

        }

        public LessonDbContext(DbContextOptions<LessonDbContext> options) : base(options)
        {

        }
    }
}
