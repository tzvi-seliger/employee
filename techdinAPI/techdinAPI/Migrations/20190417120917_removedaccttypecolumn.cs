using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class removedaccttypecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcctType",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcctType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
