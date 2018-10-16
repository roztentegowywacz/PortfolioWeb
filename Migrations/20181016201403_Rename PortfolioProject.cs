using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioWeb.Migrations
{
    public partial class RenamePortfolioProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTechnologyTags",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    TechnologyTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnologyTags", x => new { x.ProjectID, x.TechnologyTagID });
                    table.ForeignKey(
                        name: "FK_ProjectTechnologyTags_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnologyTags_TechnologyTags_TechnologyTagID",
                        column: x => x.TechnologyTagID,
                        principalTable: "TechnologyTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnologyTags_TechnologyTagID",
                table: "ProjectTechnologyTags",
                column: "TechnologyTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "PortfolioProjectTechnologyTags",
                columns: table => new
                {
                    PortfolioProjectID = table.Column<int>(nullable: false),
                    TechnologyTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioProjectTechnologyTags", x => new { x.PortfolioProjectID, x.TechnologyTagID });
                    table.ForeignKey(
                        name: "FK_PortfolioProjectTechnologyTags_PortfolioProjects_PortfolioProjectID",
                        column: x => x.PortfolioProjectID,
                        principalTable: "PortfolioProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioProjectTechnologyTags_TechnologyTags_TechnologyTagID",
                        column: x => x.TechnologyTagID,
                        principalTable: "TechnologyTags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioProjectTechnologyTags_TechnologyTagID",
                table: "PortfolioProjectTechnologyTags",
                column: "TechnologyTagID");
        }
    }
}
