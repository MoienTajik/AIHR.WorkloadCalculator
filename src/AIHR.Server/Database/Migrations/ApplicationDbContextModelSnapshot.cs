﻿// <auto-generated />
using System;
using AIHR.Server.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AIHR.Server.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AIHR.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("925a6b16-f1d9-459c-9500-5873f8b0b445"),
                            Duration = new TimeSpan(0, 8, 0, 0, 0),
                            Name = "Blockchain and HR"
                        },
                        new
                        {
                            Id = new Guid("97dcc28d-4a7c-48a2-99c6-361747536033"),
                            Duration = new TimeSpan(1, 8, 0, 0, 0),
                            Name = "Compensation & Benefits"
                        },
                        new
                        {
                            Id = new Guid("0e2ac2b9-813d-4d54-b79f-084c30924ffa"),
                            Duration = new TimeSpan(1, 16, 0, 0, 0),
                            Name = "Digital HR"
                        },
                        new
                        {
                            Id = new Guid("180c1524-5d87-4eac-b71b-3a090f4207e7"),
                            Duration = new TimeSpan(0, 10, 0, 0, 0),
                            Name = "Digital HR Strategy"
                        },
                        new
                        {
                            Id = new Guid("c4c1c37b-1c33-4ae1-b322-a540856463c3"),
                            Duration = new TimeSpan(0, 8, 0, 0, 0),
                            Name = "Digital HR Transformation"
                        },
                        new
                        {
                            Id = new Guid("eb4da35d-a6fe-4598-9191-dd2d5f4cdeda"),
                            Duration = new TimeSpan(0, 20, 0, 0, 0),
                            Name = "Diversity & Inclusion"
                        },
                        new
                        {
                            Id = new Guid("827d591c-faf8-4c7f-99e5-28c5ab4a373a"),
                            Duration = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "Employee Experience & Design Thinking"
                        },
                        new
                        {
                            Id = new Guid("62812fed-121e-42ba-8342-b939fb558567"),
                            Duration = new TimeSpan(0, 6, 0, 0, 0),
                            Name = "Employer Branding"
                        },
                        new
                        {
                            Id = new Guid("9b6274ac-3303-4aed-a35f-d2b54a2211a0"),
                            Duration = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "Global Data Integrity"
                        },
                        new
                        {
                            Id = new Guid("78de8ba8-c50c-4892-8d32-7c2887899f97"),
                            Duration = new TimeSpan(0, 15, 0, 0, 0),
                            Name = "Hiring & Recruitment Strategy"
                        },
                        new
                        {
                            Id = new Guid("cc46a407-ba94-4795-9a38-8f6233f86de6"),
                            Duration = new TimeSpan(0, 21, 0, 0, 0),
                            Name = "HR Analytics Leader"
                        },
                        new
                        {
                            Id = new Guid("ebce7a27-444c-440d-95fe-2481af72d0fd"),
                            Duration = new TimeSpan(1, 16, 0, 0, 0),
                            Name = "HR Business Partner 2.0"
                        },
                        new
                        {
                            Id = new Guid("33cf8e2c-eeb1-447c-abe2-291eb909dbfe"),
                            Duration = new TimeSpan(0, 18, 0, 0, 0),
                            Name = "HR Data Analyst"
                        },
                        new
                        {
                            Id = new Guid("255f1b74-1d31-4c43-83fc-1f0d96b4c05d"),
                            Duration = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "HR Data Science in R"
                        },
                        new
                        {
                            Id = new Guid("25c270da-d99d-4f11-9f4c-3ca1f03f340a"),
                            Duration = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "HR Data Visualization"
                        },
                        new
                        {
                            Id = new Guid("d14abd2d-1e80-4527-9266-352247744a05"),
                            Duration = new TimeSpan(1, 16, 0, 0, 0),
                            Name = "HR Metrics & Reporting"
                        },
                        new
                        {
                            Id = new Guid("245469d3-1fd8-4ebe-b0e5-71022b814a4a"),
                            Duration = new TimeSpan(1, 6, 0, 0, 0),
                            Name = "Learning & Development"
                        },
                        new
                        {
                            Id = new Guid("8d5dac51-eb56-4d42-a343-da17f9fd44eb"),
                            Duration = new TimeSpan(1, 6, 0, 0, 0),
                            Name = "Organizational Development"
                        },
                        new
                        {
                            Id = new Guid("5f186006-20f4-4bc3-9a23-3267f6b621dc"),
                            Duration = new TimeSpan(1, 16, 0, 0, 0),
                            Name = "People Analytics"
                        },
                        new
                        {
                            Id = new Guid("8f34d31a-c8fc-40a8-9109-fee5c12bd83a"),
                            Duration = new TimeSpan(0, 15, 0, 0, 0),
                            Name = "Statistics in HR"
                        },
                        new
                        {
                            Id = new Guid("22b89828-4baf-4c70-bbd1-9e13be5cbfa3"),
                            Duration = new TimeSpan(1, 10, 0, 0, 0),
                            Name = "Strategic HR Leadership"
                        },
                        new
                        {
                            Id = new Guid("f6140d82-87fa-4fbe-a06e-b6100d701772"),
                            Duration = new TimeSpan(0, 17, 0, 0, 0),
                            Name = "Strategic HR Metrics"
                        },
                        new
                        {
                            Id = new Guid("ded090be-5c43-4540-bc99-d156ad2be997"),
                            Duration = new TimeSpan(1, 16, 0, 0, 0),
                            Name = "Talent Acquisition"
                        });
                });

            modelBuilder.Entity("AIHR.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f99e35a2-42a2-4b93-a0de-c194165121d2"),
                            Name = "Marijn"
                        },
                        new
                        {
                            Id = new Guid("ab3ed2ad-ff11-42dd-88c6-ce1ca99ebb11"),
                            Name = "Moien"
                        });
                });

            modelBuilder.Entity("AIHR.Domain.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<uint>("LearningHoursPerWeek")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("MaxHoursToLearnPerDay")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<uint>("TotalWeeksInSelectedDateRange")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudyPlans", (string)null);
                });

            modelBuilder.Entity("AIHR.Domain.StudyPlanCourse", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudyPlanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId", "StudyPlanId");

                    b.HasIndex("StudyPlanId");

                    b.ToTable("StudyPlanCourses", (string)null);
                });

            modelBuilder.Entity("AIHR.Domain.UsageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<uint>("MaxHoursToLearnPerDay")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Succeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("UsageHistories", (string)null);
                });

            modelBuilder.Entity("AIHR.Domain.UsageHistoryCourse", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsageHistoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId", "UsageHistoryId");

                    b.HasIndex("UsageHistoryId");

                    b.ToTable("UsageHistoryCourses", (string)null);
                });

            modelBuilder.Entity("AIHR.Domain.StudyPlan", b =>
                {
                    b.HasOne("AIHR.Domain.Student", "Student")
                        .WithMany("StudyPlans")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AIHR.Domain.StudyPlanCourse", b =>
                {
                    b.HasOne("AIHR.Domain.Course", "Course")
                        .WithMany("StudyPlanCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIHR.Domain.StudyPlan", "StudyPlan")
                        .WithMany("StudyPlanCourses")
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("StudyPlan");
                });

            modelBuilder.Entity("AIHR.Domain.UsageHistory", b =>
                {
                    b.HasOne("AIHR.Domain.Student", "Student")
                        .WithMany("UsageHistories")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AIHR.Domain.UsageHistoryCourse", b =>
                {
                    b.HasOne("AIHR.Domain.Course", "Course")
                        .WithMany("UsageHistoryCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AIHR.Domain.UsageHistory", "UsageHistory")
                        .WithMany("UsageHistoryCourses")
                        .HasForeignKey("UsageHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("UsageHistory");
                });

            modelBuilder.Entity("AIHR.Domain.Course", b =>
                {
                    b.Navigation("StudyPlanCourses");

                    b.Navigation("UsageHistoryCourses");
                });

            modelBuilder.Entity("AIHR.Domain.Student", b =>
                {
                    b.Navigation("StudyPlans");

                    b.Navigation("UsageHistories");
                });

            modelBuilder.Entity("AIHR.Domain.StudyPlan", b =>
                {
                    b.Navigation("StudyPlanCourses");
                });

            modelBuilder.Entity("AIHR.Domain.UsageHistory", b =>
                {
                    b.Navigation("UsageHistoryCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
