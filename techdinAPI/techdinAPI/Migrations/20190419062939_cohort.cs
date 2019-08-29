using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class cohort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Cohort");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Cohort");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Cohort");

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Cohort",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Cohort");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Cohort",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Cohort",
                unicode: false,
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Cohort",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
