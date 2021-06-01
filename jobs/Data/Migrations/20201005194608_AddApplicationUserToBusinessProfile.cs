using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class AddApplicationUserToBusinessProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BusinessProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_ApplicationUserId",
                table: "BusinessProfiles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessProfiles_AspNetUsers_ApplicationUserId",
                table: "BusinessProfiles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfiles_AspNetUsers_ApplicationUserId",
                table: "BusinessProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BusinessProfiles_ApplicationUserId",
                table: "BusinessProfiles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BusinessProfiles");
        }
    }
}
