using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EgorovaMariaKt_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    AcademicDegreeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicDegreeName = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.AcademicDegreeId);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Имя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Фамилия"),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, comment: "Отчество"),
                    c_teacher_position = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    DepartmentMainTeacher = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionName = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "cd_lesson",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_lesson_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "ID преподавателя"),
                    worktime_id = table.Column<int>(type: "integer", nullable: false, comment: "ID нагрузки ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_lesson_1d", x => x.lesson_id);
                    table.ForeignKey(
                        name: "FK_cd_lesson_cd_teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_work_time",
                columns: table => new
                {
                    worktime_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_worktime_hours = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    LessonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_work_time_worktime_id", x => x.worktime_id);
                    table.ForeignKey(
                        name: "FK_cd_work_time_cd_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "cd_lesson",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx+cd_lesson_fk_f_cafedre_id",
                table: "cd_lesson",
                column: "worktime_id");

            migrationBuilder.CreateIndex(
                name: "idx+cd_lesson_fk_f_teacher_id",
                table: "cd_lesson",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_work_time_LessonId",
                table: "cd_work_time",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_lesson_cd_work_time_worktime_id",
                table: "cd_lesson",
                column: "worktime_id",
                principalTable: "cd_work_time",
                principalColumn: "worktime_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_lesson_cd_teacher_teacher_id",
                table: "cd_lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_cd_lesson_cd_work_time_worktime_id",
                table: "cd_lesson");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_work_time");

            migrationBuilder.DropTable(
                name: "cd_lesson");
        }
    }
}
