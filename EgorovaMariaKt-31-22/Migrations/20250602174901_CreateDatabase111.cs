using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EgorovaMariaKt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_degree_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название ученой степени"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название должности"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_first_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Имя преподавателя"),
                    c_last_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Фамилия преподавателя"),
                    c_middle_name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Отчество преподавателя"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_work_time",
                columns: table => new
                {
                    work_time_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_work_hours = table.Column<int>(type: "integer", nullable: false, comment: "Количество рабочих часов"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_work_time_work_time_id", x => x.work_time_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    HeadTeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_department_head_teacher",
                        column: x => x.HeadTeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_lesson",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_lesson_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название занятия"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    WorkTimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_lesson_lesson_id", x => x.lesson_id);
                    table.ForeignKey(
                        name: "fk_lesson_teacher",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lesson_work_time",
                        column: x => x.WorkTimeId,
                        principalTable: "cd_work_time",
                        principalColumn: "work_time_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_HeadTeacherId",
                table: "cd_department",
                column: "HeadTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_lesson_TeacherId",
                table: "cd_lesson",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_lesson_WorkTimeId",
                table: "cd_lesson",
                column: "WorkTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_lesson");

            migrationBuilder.DropTable(
                name: "cd_position");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_work_time");
        }
    }
}
