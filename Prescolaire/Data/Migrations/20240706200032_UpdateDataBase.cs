using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prescolaire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    classId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.classId);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    gradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.gradeId);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    managerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.managerid);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subjectId);
                });

            migrationBuilder.CreateTable(
                name: "SystemProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemProfiles_SystemProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "SystemProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordChangeOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    postalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    parentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    updateOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Manager_createdBy",
                        column: x => x.createdBy,
                        principalTable: "Manager",
                        principalColumn: "managerid");
                    table.ForeignKey(
                        name: "FK_Student_Manager_updatedBy",
                        column: x => x.updatedBy,
                        principalTable: "Manager",
                        principalColumn: "managerid");
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    dateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    postalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: true),
                    updatedBy = table.Column<int>(type: "int", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    updateOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherId);
                    table.ForeignKey(
                        name: "FK_Teacher_Manager_createdBy",
                        column: x => x.createdBy,
                        principalTable: "Manager",
                        principalColumn: "managerid");
                    table.ForeignKey(
                        name: "FK_Teacher_Manager_updatedBy",
                        column: x => x.updatedBy,
                        principalTable: "Manager",
                        principalColumn: "managerid");
                    table.ForeignKey(
                        name: "FK_Teacher_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "subjectId");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    absenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    absenceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    schoolYear = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.absenceId);
                    table.ForeignKey(
                        name: "FK_Absence_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    markId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    subjectId = table.Column<int>(type: "int", nullable: true),
                    mark1 = table.Column<double>(type: "float", nullable: true),
                    mark2 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.markId);
                    table.ForeignKey(
                        name: "FK_Marks_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                    table.ForeignKey(
                        name: "FK_Marks_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "subjectId");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPayment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    paymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    paymentMonth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    schoolYear = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPayment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_MonthlyPayment_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    studentClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    classId = table.Column<int>(type: "int", nullable: true),
                    schoolYear = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => x.studentClass);
                    table.ForeignKey(
                        name: "FK_StudentClass_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "classId");
                    table.ForeignKey(
                        name: "FK_StudentClass_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentGrade",
                columns: table => new
                {
                    studentGradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    gradeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrade", x => x.studentGradeId);
                    table.ForeignKey(
                        name: "FK_StudentGrade_Grade_gradeId",
                        column: x => x.gradeId,
                        principalTable: "Grade",
                        principalColumn: "gradeId");
                    table.ForeignKey(
                        name: "FK_StudentGrade_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "TeacherClass",
                columns: table => new
                {
                    teacherClass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classId = table.Column<int>(type: "int", nullable: true),
                    teacherId = table.Column<int>(type: "int", nullable: true),
                    schoolYear = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClass", x => x.teacherClass);
                    table.ForeignKey(
                        name: "FK_TeacherClass_Class_classId",
                        column: x => x.classId,
                        principalTable: "Class",
                        principalColumn: "classId");
                    table.ForeignKey(
                        name: "FK_TeacherClass_Teacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teacher",
                        principalColumn: "teacherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_studentId",
                table: "Absence",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_studentId",
                table: "Marks",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_subjectId",
                table: "Marks",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPayment_studentId",
                table: "MonthlyPayment",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_createdBy",
                table: "Student",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Student_updatedBy",
                table: "Student",
                column: "updatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_classId",
                table: "StudentClass",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_studentId",
                table: "StudentClass",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_gradeId",
                table: "StudentGrade",
                column: "gradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrade_studentId",
                table: "StudentGrade",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProfiles_ProfileId",
                table: "SystemProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_createdBy",
                table: "Teacher",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_subjectId",
                table: "Teacher",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_updatedBy",
                table: "Teacher",
                column: "updatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_classId",
                table: "TeacherClass",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_teacherId",
                table: "TeacherClass",
                column: "teacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "MonthlyPayment");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "StudentGrade");

            migrationBuilder.DropTable(
                name: "SystemProfiles");

            migrationBuilder.DropTable(
                name: "TeacherClass");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
