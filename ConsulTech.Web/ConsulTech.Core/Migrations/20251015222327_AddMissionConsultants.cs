using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsulTech.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddMissionConsultants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Consultants_ConsultantId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_ConsultantId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Missions");

            migrationBuilder.CreateTable(
                name: "MissionConsultant",
                columns: table => new
                {
                    ConsultantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionConsultant", x => new { x.ConsultantId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_MissionConsultant_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionConsultant_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionConsultant_MissionId",
                table: "MissionConsultant",
                column: "MissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionConsultant");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantId",
                table: "Missions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_ConsultantId",
                table: "Missions",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Consultants_ConsultantId",
                table: "Missions",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id");
        }
    }
}
