using Microsoft.EntityFrameworkCore.Migrations;

namespace jobs.Data.Migrations
{
    public partial class SeedRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Employer', N'EMPLOYER', N'')");
            migrationBuilder.Sql("INSERT[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES(N'2', N'Candidate', N'CANDIDATE', NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");
        }
    }
}
