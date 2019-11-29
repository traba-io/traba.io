using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ChangeCompanyUriToNamespace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Namespace",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namespace",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Companies",
                type: "text",
                nullable: true);
        }
    }
}
