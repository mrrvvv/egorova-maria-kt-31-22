using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    public class WorkTimeConfiguration : IEntityTypeConfiguration<WorkTime>
    {
        private const string TableName = "cd_work_time";

        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            //builder.ToTable(TableName);

            builder.HasKey(p => p.WorkTimeId)
                   .HasName($"pk_{TableName}_worktime_id");

            // Для целочисленного первичного клеча задаем автогенерацию (к каждой новой записи будет добавлять +1) builder.Property(p=> p.StudentId)
            builder.Property(p => p.WorkTimeId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.WorkTimeId)
                   .HasColumnName("worktime_id")
                   .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.WorkTimeHours)
                   .IsRequired()
                   .HasColumnName("c_worktime_hours")
                   .HasMaxLength(50);


            // Остальные свойства...

            builder.Property(p => p.IsDeleted)
                   .HasColumnName("is_deleted")
                   .HasDefaultValue(false);

            // Связи
            builder.HasOne(p => p.Lesson)
                   .WithMany(l => l.WorkTimes)
                   .HasForeignKey(p => p.LessonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName);
        }
    }
}
