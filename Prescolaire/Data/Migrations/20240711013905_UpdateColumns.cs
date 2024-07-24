using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescolaire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Class_classId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Student_studentId",
                table: "StudentClass");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "classId",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Class_classId",
                table: "StudentClass",
                column: "classId",
                principalTable: "Class",
                principalColumn: "classId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Student_studentId",
                table: "StudentClass",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Class_classId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Student_studentId",
                table: "StudentClass");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "StudentClass",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "classId",
                table: "StudentClass",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Class_classId",
                table: "StudentClass",
                column: "classId",
                principalTable: "Class",
                principalColumn: "classId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Student_studentId",
                table: "StudentClass",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");
        }
    }
}
