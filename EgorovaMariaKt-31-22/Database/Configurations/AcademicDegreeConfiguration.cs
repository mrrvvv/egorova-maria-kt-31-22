using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для ученой степени
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        private const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            // Установка первичного ключа
            builder.HasKey(a => a.AcademicDegreeId)
                   .HasName($"pk_{TableName}_academic_degree_id");

            // Настройка столбца ID
            builder.Property(a => a.AcademicDegreeId)
                  .HasColumnName("academic_degree_id")
                  .ValueGeneratedOnAdd();

            // Настройка названия ученой степени
            builder.Property(a => a.AcademicDegreeName)
                  .IsRequired()
                  .HasColumnName("c_degree_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(100)
                  .HasComment("Название ученой степени");

            // Мягкое удаление
            builder.Property(a => a.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}
