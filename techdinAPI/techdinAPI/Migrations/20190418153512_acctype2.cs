using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class acctype2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcctType",
                table: "Invitations");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Invitations",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Invitations");

            migrationBuilder.AddColumn<string>(
                name: "AcctType",
                table: "Invitations",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
