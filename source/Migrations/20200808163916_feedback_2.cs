using Microsoft.EntityFrameworkCore.Migrations;

namespace Feedback.API.Migrations
{
    public partial class feedback_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceKey",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationPublicKey",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationPublicKey",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "DeviceKey",
                table: "Applications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
