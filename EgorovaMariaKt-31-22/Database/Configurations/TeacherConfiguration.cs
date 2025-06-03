using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для преподавателя
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId)
                   .HasName($"pk_{TableName}_teacher_id");

            builder.Property(t => t.TeacherId)
                  .HasColumnName("teacher_id")
                  .ValueGeneratedOnAdd();

            builder.Property(t => t.TeacherFirstName)
                  .IsRequired()
                  .HasColumnName("c_first_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(50)
                  .HasComment("Имя преподавателя");

            builder.Property(t => t.TeacherLastName)
                  .IsRequired()
                  .HasColumnName("c_last_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(50)
                  .HasComment("Фамилия преподавателя");

            builder.Property(t => t.TeacherMiddleName)
                  .HasColumnName("c_middle_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(50)
                  .HasComment("Отчество преподавателя");

            builder.Property(t => t.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}