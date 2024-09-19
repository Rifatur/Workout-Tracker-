using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutTracker.Infrastructure.Data.Migrationfiles
{
    /// <inheritdoc />
    public partial class UpdateWorkoutPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WorkoutPlans");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Category", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "MuscleGroup", "Name" },
                values: new object[,]
                {
                    { new Guid("0874fcd8-1416-4c40-af37-17a758fc3b50"), "Strength", new DateTime(2024, 9, 18, 22, 10, 30, 83, DateTimeKind.Utc).AddTicks(4652), null, "Push-Up exercise", null, null, "Chest", "Push-Up" },
                    { new Guid("50f88883-59b6-4af6-9903-dd3e0b39b0d5"), "Strength", new DateTime(2024, 9, 18, 22, 10, 30, 83, DateTimeKind.Utc).AddTicks(4719), null, "Squat exercise", null, null, "Legs", "Squat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("0874fcd8-1416-4c40-af37-17a758fc3b50"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("50f88883-59b6-4af6-9903-dd3e0b39b0d5"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "WorkoutPlans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
