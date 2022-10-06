using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIHR.Server.Database.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    MaxHoursToLearnPerDay = table.Column<uint>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalWeeksInSelectedDateRange = table.Column<uint>(type: "INTEGER", nullable: false),
                    LearningHoursPerWeek = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanCourses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudyPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanCourses", x => new { x.CourseId, x.StudyPlanId });
                    table.ForeignKey(
                        name: "FK_StudyPlanCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyPlanCourses_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("0e2ac2b9-813d-4d54-b79f-084c30924ffa"), new TimeSpan(1, 16, 0, 0, 0), "Digital HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("180c1524-5d87-4eac-b71b-3a090f4207e7"), new TimeSpan(0, 10, 0, 0, 0), "Digital HR Strategy" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("22b89828-4baf-4c70-bbd1-9e13be5cbfa3"), new TimeSpan(1, 10, 0, 0, 0), "Strategic HR Leadership" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("245469d3-1fd8-4ebe-b0e5-71022b814a4a"), new TimeSpan(1, 6, 0, 0, 0), "Learning & Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("255f1b74-1d31-4c43-83fc-1f0d96b4c05d"), new TimeSpan(0, 12, 0, 0, 0), "HR Data Science in R" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("25c270da-d99d-4f11-9f4c-3ca1f03f340a"), new TimeSpan(0, 12, 0, 0, 0), "HR Data Visualization" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("33cf8e2c-eeb1-447c-abe2-291eb909dbfe"), new TimeSpan(0, 18, 0, 0, 0), "HR Data Analyst" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("5f186006-20f4-4bc3-9a23-3267f6b621dc"), new TimeSpan(1, 16, 0, 0, 0), "People Analytics" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("62812fed-121e-42ba-8342-b939fb558567"), new TimeSpan(0, 6, 0, 0, 0), "Employer Branding" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("78de8ba8-c50c-4892-8d32-7c2887899f97"), new TimeSpan(0, 15, 0, 0, 0), "Hiring & Recruitment Strategy" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("827d591c-faf8-4c7f-99e5-28c5ab4a373a"), new TimeSpan(0, 12, 0, 0, 0), "Employee Experience & Design Thinking" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("8d5dac51-eb56-4d42-a343-da17f9fd44eb"), new TimeSpan(1, 6, 0, 0, 0), "Organizational Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("8f34d31a-c8fc-40a8-9109-fee5c12bd83a"), new TimeSpan(0, 15, 0, 0, 0), "Statistics in HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("925a6b16-f1d9-459c-9500-5873f8b0b445"), new TimeSpan(0, 8, 0, 0, 0), "Blockchain and HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("97dcc28d-4a7c-48a2-99c6-361747536033"), new TimeSpan(1, 8, 0, 0, 0), "Compensation & Benefits" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("9b6274ac-3303-4aed-a35f-d2b54a2211a0"), new TimeSpan(0, 12, 0, 0, 0), "Global Data Integrity" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("c4c1c37b-1c33-4ae1-b322-a540856463c3"), new TimeSpan(0, 8, 0, 0, 0), "Digital HR Transformation" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("cc46a407-ba94-4795-9a38-8f6233f86de6"), new TimeSpan(0, 21, 0, 0, 0), "HR Analytics Leader" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("d14abd2d-1e80-4527-9266-352247744a05"), new TimeSpan(1, 16, 0, 0, 0), "HR Metrics & Reporting" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("ded090be-5c43-4540-bc99-d156ad2be997"), new TimeSpan(1, 16, 0, 0, 0), "Talent Acquisition" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("eb4da35d-a6fe-4598-9191-dd2d5f4cdeda"), new TimeSpan(0, 20, 0, 0, 0), "Diversity & Inclusion" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("ebce7a27-444c-440d-95fe-2481af72d0fd"), new TimeSpan(1, 16, 0, 0, 0), "HR Business Partner 2.0" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { new Guid("f6140d82-87fa-4fbe-a06e-b6100d701772"), new TimeSpan(0, 17, 0, 0, 0), "Strategic HR Metrics" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ab3ed2ad-ff11-42dd-88c6-ce1ca99ebb11"), "Moien" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f99e35a2-42a2-4b93-a0de-c194165121d2"), "Marijn" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name",
                table: "Courses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanCourses_StudyPlanId",
                table: "StudyPlanCourses",
                column: "StudyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_StudentId",
                table: "StudyPlans",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyPlanCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
