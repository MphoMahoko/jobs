using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class AddBusinessProfileToJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_applicationUserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_applicationUserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "businessProfileId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_businessProfileId",
                table: "Jobs",
                column: "businessProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_BusinessProfiles_businessProfileId",
                table: "Jobs",
                column: "businessProfileId",
                principalTable: "BusinessProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_BusinessProfiles_businessProfileId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_businessProfileId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "businessProfileId",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_applicationUserId",
                table: "Jobs",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_applicationUserId",
                table: "Jobs",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
