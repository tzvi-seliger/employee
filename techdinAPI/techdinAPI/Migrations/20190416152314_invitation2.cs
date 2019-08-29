using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class invitation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Invitations_Email",
                table: "Invitations",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Invitations_Email",
                table: "Invitations");
        }
    }
}
