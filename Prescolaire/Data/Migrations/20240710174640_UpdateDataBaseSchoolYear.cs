using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescolaire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBaseSchoolYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "schoolYear",
                table: "TeacherClass");

            migrationBuilder.DropColumn(
                name: "schoolYear",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "schoolYear",
                table: "MonthlyPayment");

            migrationBuilder.DropColumn(
                name: "schoolYear",
                table: "Absence");

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "TeacherClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "MonthlyPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "Marks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "Absence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SchoolYear",
                columns: table => new
                {
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYear", x => x.SchoolYearId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_schoolYearId",
                table: "TeacherClass",
                column: "schoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_schoolYearId",
                table: "StudentClass",
                column: "schoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPayment_schoolYearId",
                table: "MonthlyPayment",
                column: "schoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_schoolYearId",
                table: "Marks",
                column: "schoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_schoolYearId",
                table: "Class",
                column: "schoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_schoolYearId",
                table: "Absence",
                column: "schoolYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_SchoolYear_schoolYearId",
                table: "Absence",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_SchoolYear_schoolYearId",
                table: "Class",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_SchoolYear_schoolYearId",
                table: "Marks",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPayment_SchoolYear_schoolYearId",
                table: "MonthlyPayment",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_SchoolYear_schoolYearId",
                table: "StudentClass",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClass_SchoolYear_schoolYearId",
                table: "TeacherClass",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_SchoolYear_schoolYearId",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_SchoolYear_schoolYearId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_SchoolYear_schoolYearId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyPayment_SchoolYear_schoolYearId",
                table: "MonthlyPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_SchoolYear_schoolYearId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherClass_SchoolYear_schoolYearId",
                table: "TeacherClass");

            migrationBuilder.DropTable(
                name: "SchoolYear");

            migrationBuilder.DropIndex(
                name: "IX_TeacherClass_schoolYearId",
                table: "TeacherClass");

            migrationBuilder.DropIndex(
                name: "IX_StudentClass_schoolYearId",
                table: "StudentClass");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyPayment_schoolYearId",
                table: "MonthlyPayment");

            migrationBuilder.DropIndex(
                name: "IX_Marks_schoolYearId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Class_schoolYearId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Absence_schoolYearId",
                table: "Absence");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "TeacherClass");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "MonthlyPayment");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "Absence");

            migrationBuilder.AddColumn<string>(
                name: "schoolYear",
                table: "TeacherClass",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "schoolYear",
                table: "StudentClass",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "schoolYear",
                table: "MonthlyPayment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "schoolYear",
                table: "Absence",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
