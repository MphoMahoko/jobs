using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class AddExperienceToJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationExperience",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceYears",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsibilities",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "Jobs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EducationExperience",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Responsibilities",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "Jobs");
        }
    }
}
