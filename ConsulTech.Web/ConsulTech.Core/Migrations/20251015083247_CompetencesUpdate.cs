using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsulTech.Core.Migrations
{
    /// <inheritdoc />
    public partial class CompetencesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_Consultants_ConsultantId",
                table: "Competences");

            migrationBuilder.DropIndex(
                name: "IX_Competences_ConsultantId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Competences");

            migrationBuilder.CreateTable(
                name: "CompetenceConsultant",
                columns: table => new
                {
                    CompetencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceConsultant", x => new { x.CompetencesId, x.ConsultantsId });
                    table.ForeignKey(
                        name: "FK_CompetenceConsultant_Competences_CompetencesId",
                        column: x => x.CompetencesId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenceConsultant_Consultants_ConsultantsId",
                        column: x => x.ConsultantsId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceConsultant_ConsultantsId",
                table: "CompetenceConsultant",
                column: "ConsultantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceConsultant");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantId",
                table: "Competences",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competences_ConsultantId",
                table: "Competences",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_Consultants_ConsultantId",
                table: "Competences",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id");
        }
    }
}
