using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для кафедры
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId)
                   .HasName($"pk_{TableName}_department_id");

            builder.Property(d => d.DepartmentId)
                  .HasColumnName("department_id")
                  .ValueGeneratedOnAdd();

            builder.Property(d => d.DepartmentName)
                  .IsRequired()
                  .HasColumnName("c_department_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(100)
                  .HasComment("Название кафедры");

            // Внешний ключ для заведующего кафедрой
            builder.HasOne(d => d.HeadTeacher)
                  .WithMany()
                  .HasForeignKey(d => d.HeadTeacherId)
                  .HasConstraintName("fk_department_head_teacher")
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}