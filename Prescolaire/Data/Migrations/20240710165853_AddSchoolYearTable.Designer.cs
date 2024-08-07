﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prescolaire.Data;

#nullable disable

namespace Prescolaire.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240710165853_AddSchoolYearTable")]
    partial class AddSchoolYearTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Prescolaire.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("absenceId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AbsenceId"));

                    b.Property<DateTime>("AbsenceDate")
                        .HasColumnType("datetime")
                        .HasColumnName("absenceDate");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("schoolYear");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("AbsenceId");

                    b.HasIndex("StudentId");

                    b.ToTable("Absence");
                });

            modelBuilder.Entity("Prescolaire.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("LoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("PasswordChangeOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Prescolaire.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("className");

                    b.HasKey("ClassId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Prescolaire.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("gradeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<string>("GradeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("gradeName");

                    b.HasKey("GradeId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("Prescolaire.Models.Manager", b =>
                {
                    b.Property<int>("Managerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("managerid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Managerid"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("firstName");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("username");

                    b.HasKey("Managerid");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("Prescolaire.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("markId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<double?>("Mark1")
                        .HasColumnType("float")
                        .HasColumnName("mark1");

                    b.Property<double?>("Mark2")
                        .HasColumnType("float")
                        .HasColumnName("mark2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subjectId");

                    b.HasKey("MarkId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Prescolaire.Models.MonthlyPayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date")
                        .HasColumnName("paymentDate");

                    b.Property<string>("PaymentMonth")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("paymentMonth");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("schoolYear");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("PaymentId");

                    b.HasIndex("StudentId");

                    b.ToTable("MonthlyPayment");
                });

            modelBuilder.Entity("Prescolaire.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("country");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("createdBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("firstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("lastName");

                    b.Property<string>("ParentName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("parentName");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("phoneNumber");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("postalCode");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("region");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("street");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updateOn");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int")
                        .HasColumnName("updatedBy");

                    b.HasKey("StudentId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Prescolaire.Models.StudentClass", b =>
                {
                    b.Property<int>("StudentClass1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentClass");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentClass1"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("schoolYear");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("StudentClass1");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("Prescolaire.Models.StudentGrade", b =>
                {
                    b.Property<int>("StudentGradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("studentGradeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentGradeId"));

                    b.Property<int?>("GradeId")
                        .HasColumnType("int")
                        .HasColumnName("gradeId");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("StudentGradeId");

                    b.HasIndex("GradeId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGrade");
                });

            modelBuilder.Entity("Prescolaire.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subjectId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("subjectName");

                    b.HasKey("SubjectId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Prescolaire.Models.SystemProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("SystemProfiles");
                });

            modelBuilder.Entity("Prescolaire.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacherId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("country");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("createdBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("firstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("phoneNumber");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("postalCode");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("region");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("street");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subjectId");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updateOn");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int")
                        .HasColumnName("updatedBy");

                    b.HasKey("TeacherId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Prescolaire.Models.TeacherClass", b =>
                {
                    b.Property<int>("TeacherClass1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("teacherClass");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherClass1"));

                    b.Property<int?>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("schoolYear");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int")
                        .HasColumnName("teacherId");

                    b.HasKey("TeacherClass1");

                    b.HasIndex("ClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherClass");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Prescolaire.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Prescolaire.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prescolaire.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Prescolaire.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prescolaire.Models.Absence", b =>
                {
                    b.HasOne("Prescolaire.Models.Student", "Student")
                        .WithMany("Absences")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Prescolaire.Models.ApplicationUser", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Prescolaire.Models.Mark", b =>
                {
                    b.HasOne("Prescolaire.Models.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId");

                    b.HasOne("Prescolaire.Models.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Prescolaire.Models.MonthlyPayment", b =>
                {
                    b.HasOne("Prescolaire.Models.Student", "Student")
                        .WithMany("MonthlyPayments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Prescolaire.Models.Student", b =>
                {
                    b.HasOne("Prescolaire.Models.Manager", "CreatedByNavigation")
                        .WithMany("StudentCreatedByNavigations")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Prescolaire.Models.Manager", "UpdatedByNavigation")
                        .WithMany("StudentUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("Prescolaire.Models.StudentClass", b =>
                {
                    b.HasOne("Prescolaire.Models.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId");

                    b.HasOne("Prescolaire.Models.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Prescolaire.Models.StudentGrade", b =>
                {
                    b.HasOne("Prescolaire.Models.Grade", "Grade")
                        .WithMany("StudentGrades")
                        .HasForeignKey("GradeId");

                    b.HasOne("Prescolaire.Models.Student", "Student")
                        .WithMany("StudentGrades")
                        .HasForeignKey("StudentId");

                    b.Navigation("Grade");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Prescolaire.Models.SystemProfile", b =>
                {
                    b.HasOne("Prescolaire.Models.SystemProfile", "Profile")
                        .WithMany("Children")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Prescolaire.Models.Teacher", b =>
                {
                    b.HasOne("Prescolaire.Models.Manager", "CreatedByNavigation")
                        .WithMany("TeacherCreatedByNavigations")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Prescolaire.Models.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId");

                    b.HasOne("Prescolaire.Models.Manager", "UpdatedByNavigation")
                        .WithMany("TeacherUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("Subject");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("Prescolaire.Models.TeacherClass", b =>
                {
                    b.HasOne("Prescolaire.Models.Class", "Class")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("ClassId");

                    b.HasOne("Prescolaire.Models.Teacher", "Teacher")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Prescolaire.Models.Class", b =>
                {
                    b.Navigation("StudentClasses");

                    b.Navigation("TeacherClasses");
                });

            modelBuilder.Entity("Prescolaire.Models.Grade", b =>
                {
                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("Prescolaire.Models.Manager", b =>
                {
                    b.Navigation("StudentCreatedByNavigations");

                    b.Navigation("StudentUpdatedByNavigations");

                    b.Navigation("TeacherCreatedByNavigations");

                    b.Navigation("TeacherUpdatedByNavigations");
                });

            modelBuilder.Entity("Prescolaire.Models.Student", b =>
                {
                    b.Navigation("Absences");

                    b.Navigation("Marks");

                    b.Navigation("MonthlyPayments");

                    b.Navigation("StudentClasses");

                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("Prescolaire.Models.Subject", b =>
                {
                    b.Navigation("Marks");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("Prescolaire.Models.SystemProfile", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Prescolaire.Models.Teacher", b =>
                {
                    b.Navigation("TeacherClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
