using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescolaire.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateClassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Class_schoolYearId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "schoolYearId",
                table: "Class");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_SchoolYear_schoolYearId",
                table: "Absence",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_SchoolYear_schoolYearId",
                table: "Marks",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyPayment_SchoolYear_schoolYearId",
                table: "MonthlyPayment",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_SchoolYear_schoolYearId",
                table: "StudentClass",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherClass_SchoolYear_schoolYearId",
                table: "TeacherClass",
                column: "schoolYearId",
                principalTable: "SchoolYear",
                principalColumn: "SchoolYearId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_SchoolYear_schoolYearId",
                table: "Absence");

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

            migrationBuilder.AddColumn<int>(
                name: "schoolYearId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Class_schoolYearId",
                table: "Class",
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
    }
}
