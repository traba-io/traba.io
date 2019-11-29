using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ChangeCompanyUriToNamespace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "JobOpportunities");

            migrationBuilder.AddColumn<string>(
                name: "Namespace",
                table: "JobOpportunities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namespace",
                table: "JobOpportunities");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "JobOpportunities",
                type: "text",
                nullable: true);
        }
    }
}
