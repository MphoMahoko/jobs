using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class changeBrofileToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_BrofileId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "BrofileId",
                table: "Messages",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_BrofileId",
                table: "Messages",
                newName: "IX_Messages_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_ProfileId",
                table: "Messages",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_ProfileId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Messages",
                newName: "BrofileId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ProfileId",
                table: "Messages",
                newName: "IX_Messages_BrofileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_BrofileId",
                table: "Messages",
                column: "BrofileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
