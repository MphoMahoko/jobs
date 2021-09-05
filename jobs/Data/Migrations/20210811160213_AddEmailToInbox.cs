using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class AddEmailToInbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Inboxes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Inboxes");
        }
    }
}
