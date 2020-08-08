using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Feedback.API.Migrations
{
    public partial class feedback_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ApplicationId",
                table: "Feedback",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeviceKey = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ApplicationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApplicationId",
                table: "Feedback",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Applications_ApplicationId",
                table: "Feedback",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Applications_ApplicationId",
                table: "Feedback");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_ApplicationId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Feedback");
        }
    }
}
