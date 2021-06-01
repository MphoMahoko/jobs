using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class ChangebusinessToBusinessProfileOnMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BusinessProfiles_businessId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "businessId",
                table: "Messages",
                newName: "businessProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_businessId",
                table: "Messages",
                newName: "IX_Messages_businessProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BusinessProfiles_businessProfileId",
                table: "Messages",
                column: "businessProfileId",
                principalTable: "BusinessProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BusinessProfiles_businessProfileId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "businessProfileId",
                table: "Messages",
                newName: "businessId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_businessProfileId",
                table: "Messages",
                newName: "IX_Messages_businessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BusinessProfiles_businessId",
                table: "Messages",
                column: "businessId",
                principalTable: "BusinessProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
