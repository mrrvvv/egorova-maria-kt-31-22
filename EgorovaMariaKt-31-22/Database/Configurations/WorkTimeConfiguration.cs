using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для рабочего времени
    public class WorkTimeConfiguration : IEntityTypeConfiguration<WorkTime>
    {
        private const string TableName = "cd_work_time";

        public void Configure(EntityTypeBuilder<WorkTime> builder)
        {
            builder.HasKey(w => w.WorkTimeId)
                   .HasName($"pk_{TableName}_work_time_id");

            builder.Property(w => w.WorkTimeId)
                  .HasColumnName("work_time_id")
                  .ValueGeneratedOnAdd();

            builder.Property(w => w.WorkTimeHours)
                  .IsRequired()
                  .HasColumnName("c_work_hours")
                  .HasComment("Количество рабочих часов");

            builder.Property(w => w.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}