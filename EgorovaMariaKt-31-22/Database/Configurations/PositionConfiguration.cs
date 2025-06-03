using EgorovaMariaKt_31_22.Database.Helpers;
using EgorovaMariaKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgorovaMariaKt_31_22.Database.Configurations
{
    // Конфигурация для должности
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId)
                   .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                  .HasColumnName("position_id")
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.PositionName)
                  .IsRequired()
                  .HasColumnName("c_position_name")
                  .HasColumnType(ColumnType.String).HasMaxLength(100)
                  .HasComment("Название должности");

            builder.Property(p => p.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasDefaultValue(false);

            builder.ToTable(TableName);
        }
    }
}