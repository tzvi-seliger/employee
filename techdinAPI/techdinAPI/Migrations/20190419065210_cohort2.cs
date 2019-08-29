using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class cohort2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CohortID",
                table: "AspNetUsers",
                newName: "CohortId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CohortID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CohortId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "CohortID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CohortId",
                table: "AspNetUsers",
                newName: "CohortID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_CohortId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_CohortID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortID",
                table: "AspNetUsers",
                column: "CohortID",
                principalTable: "Cohort",
                principalColumn: "CohortID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
