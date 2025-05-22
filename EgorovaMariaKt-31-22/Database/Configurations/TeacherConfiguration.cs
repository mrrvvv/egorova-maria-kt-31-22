using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EgorovaMariaKt_31_22.Database.Helpers;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //builder.ToTable(TableName);

            builder.HasKey(t => t.TeacherId)
                   .HasName($"pk_{TableName}_teacher_id");

            // Для целочисленного первичного клеча задаем автогенерацию (к каждой новой записи будет добавлять +1) builder.Property(p=> p.StudentId)
            builder.Property(p => p.TeacherId)
                    .ValueGeneratedOnAdd();

            builder.Property(t => t.TeacherId)
                   .HasColumnName("teacher_id")
                   .HasComment("Идентификатор записи преподавателя");

            builder.Property(t => t.TeacherFirstName)
                   .IsRequired()
                   .HasColumnName("c_teacher_firstname")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Имя");

            builder.Property(t => t.TeacherLastName)
                   .IsRequired()
                   .HasColumnName("c_teacher_lastname")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Фамилия");

            builder.Property(t => t.TeacherMiddleName)
                   .IsRequired()
                   .HasColumnName("c_teacher_middlename")
                   .HasColumnType(ColumnType.String).HasMaxLength(50)
                   .HasComment("Отчество");

            builder.Property(t => t.TeacherPosition)
                   .IsRequired()
                   .HasColumnName("c_teacher_position")
                   .HasMaxLength(50);


            // Остальные свойства...

            builder.Property(t => t.IsDeleted)
                   .HasColumnName("is_deleted")
                   .HasDefaultValue(false);

            builder.ToTable(TableName);

        }
    }
}
