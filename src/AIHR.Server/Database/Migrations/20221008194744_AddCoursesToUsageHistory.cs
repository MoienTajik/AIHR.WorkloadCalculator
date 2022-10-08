using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIHR.Server.Database.Migrations;

public partial class AddCoursesToUsageHistory : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "UsageHistoryCourses",
            columns: table => new
            {
                CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                UsageHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsageHistoryCourses", x => new { x.CourseId, x.UsageHistoryId });
                table.ForeignKey(
                    name: "FK_UsageHistoryCourses_Courses_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_UsageHistoryCourses_UsageHistories_UsageHistoryId",
                    column: x => x.UsageHistoryId,
                    principalTable: "UsageHistories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_UsageHistoryCourses_UsageHistoryId",
            table: "UsageHistoryCourses",
            column: "UsageHistoryId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "UsageHistoryCourses");
    }
}