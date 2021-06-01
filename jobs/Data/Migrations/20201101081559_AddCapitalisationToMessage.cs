using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class AddCapitalisationToMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BusinessProfiles_businessProfileId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Jobs_jobId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_profileId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "jobId",
                table: "Messages",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "businessProfileId",
                table: "Messages",
                newName: "BusinessProfileId");

            migrationBuilder.RenameColumn(
                name: "profileId",
                table: "Messages",
                newName: "BrofileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_jobId",
                table: "Messages",
                newName: "IX_Messages_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_businessProfileId",
                table: "Messages",
                newName: "IX_Messages_BusinessProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_profileId",
                table: "Messages",
                newName: "IX_Messages_BrofileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_BrofileId",
                table: "Messages",
                column: "BrofileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BusinessProfiles_BusinessProfileId",
                table: "Messages",
                column: "BusinessProfileId",
                principalTable: "BusinessProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Jobs_JobId",
                table: "Messages",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_BrofileId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BusinessProfiles_BusinessProfileId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Jobs_JobId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Messages",
                newName: "jobId");

            migrationBuilder.RenameColumn(
                name: "BusinessProfileId",
                table: "Messages",
                newName: "businessProfileId");

            migrationBuilder.RenameColumn(
                name: "BrofileId",
                table: "Messages",
                newName: "profileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_JobId",
                table: "Messages",
                newName: "IX_Messages_jobId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_BusinessProfileId",
                table: "Messages",
                newName: "IX_Messages_businessProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_BrofileId",
                table: "Messages",
                newName: "IX_Messages_profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BusinessProfiles_businessProfileId",
                table: "Messages",
                column: "businessProfileId",
                principalTable: "BusinessProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Jobs_jobId",
                table: "Messages",
                column: "jobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_profileId",
                table: "Messages",
                column: "profileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
