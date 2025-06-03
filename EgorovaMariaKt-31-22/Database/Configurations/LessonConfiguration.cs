using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для занятия
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        private const string TableName = "cd_lesson";

        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.LessonId)
                   .HasName($"pk_{TableName}_lesson_id");

            builder.Property(l => l.LessonId)
                  .HasColumnName("lesson_id")
                  .ValueGeneratedOnAdd();

            builder.Property(l => l.LessonName)
                  .IsRequired()
                  .HasColumnName("c_lesson_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(100)
                  .HasComment("Название занятия");

            // Связь с преподавателем
            builder.HasOne(l => l.Teacher)
                  .WithMany()
                  .HasForeignKey(l => l.TeacherId)
                  .HasConstraintName("fk_lesson_teacher")
                  .OnDelete(DeleteBehavior.Restrict);

            // Связь с рабочим временем
            builder.HasOne(l => l.WorkTime)
                  .WithMany()
                  .HasForeignKey(l => l.WorkTimeId)
                  .HasConstraintName("fk_lesson_work_time")
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Property(l => l.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}