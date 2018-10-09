using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioWeb.Migrations
{
    public partial class Addcommercialandwebcategoriestoproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCommercial",
                table: "PortfolioProjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWebProject",
                table: "PortfolioProjects",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCommercial",
                table: "PortfolioProjects");

            migrationBuilder.DropColumn(
                name: "IsWebProject",
                table: "PortfolioProjects");
        }
    }
}
