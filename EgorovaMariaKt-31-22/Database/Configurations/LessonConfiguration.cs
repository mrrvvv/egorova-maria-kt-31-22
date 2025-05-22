using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        //Название таблицы, которое будет отображаться в БД
        private const string TableName = "cd_lesson";
        public void Configure(EntityTypeBuilder<Lesson> builder) 
        {
            // Задаем первичный клеч
            builder
            .HasKey(p => p.LessonId)
            .HasName($"pk_(TableName)_lesson_1d");

            // Для целочисленного первичного клеча задаем автогенерацию (к каждой новой записи будет добавлять +1) builder.Property(p=> p.StudentId)
            builder.Property(p=>p.LessonId)   
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд builder.Property(p=> p.StudentId)
            builder.Property(p => p.LessonId)
                .HasColumnName("lesson_id")
                .HasComment("Идентификатор записи дисциплины");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию) builder. Property(p=> p.FirstName)
            builder.Property(p => p.LessonName)
                .IsRequired()
                .HasColumnName("c_lesson_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");

            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("ID преподавателя");

            builder.Property(p => p.WorkTimeHours)
                .HasColumnName("worktime_id")               
                .HasComment("ID нагрузки ");


            builder.Property(p => p.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

            //Связи
            builder.HasOne(p => p.Teacher)
                   .WithMany(t => t.Lessons)
                   .HasForeignKey(p => p.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            //Связи
            builder.HasOne(p => p.WorkTime)
                   .WithMany(w => w.Lessons)
                   .HasForeignKey(p => p.WorkTimeHours)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.TeacherId, $"idx+{TableName}_fk_f_teacher_id");
            builder.HasIndex(p => p.WorkTimeHours, $"idx+{TableName}_fk_f_cafedre_id");

            builder.ToTable(TableName);

        }
    }
}
