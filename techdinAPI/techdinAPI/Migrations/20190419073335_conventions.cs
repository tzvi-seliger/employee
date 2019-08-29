using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class conventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestsUsers");

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    InterestName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.UserName, x.InterestName });
                    table.ForeignKey(
                        name: "FK_UserInterests_AspNetUsers_InterestName",
                        column: x => x.InterestName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterests_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestName",
                table: "UserInterests",
                column: "InterestName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.CreateTable(
                name: "InterestsUsers",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    InterestName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsUsers", x => new { x.UserName, x.InterestName });
                    table.ForeignKey(
                        name: "FK_InterestsUsers_AspNetUsers_InterestName",
                        column: x => x.InterestName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterestsUsers_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestsUsers_InterestName",
                table: "InterestsUsers",
                column: "InterestName");
        }
    }
}
