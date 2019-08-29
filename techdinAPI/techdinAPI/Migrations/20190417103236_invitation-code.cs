using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechdinAPI.Migrations
{
    public partial class invitationcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "InvKey",
                table: "Invitations",
                nullable: false,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InvKey",
                table: "Invitations",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "AspNetUsers",
                unicode: false,
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
