using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetworkBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamPlayerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Teams_TeamAId",
                table: "Match",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Teams_TeamBId",
                table: "Match",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TeamMembership",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembership_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembership_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_Teams_TeamAId",
                table: "Match",
                column: "Teams_TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Teams_TeamBId",
                table: "Match",
                column: "Teams_TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembership_PlayerId",
                table: "TeamMembership",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembership_TeamId",
                table: "TeamMembership",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_Teams_TeamAId",
                table: "Match",
                column: "Teams_TeamAId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Teams_Teams_TeamBId",
                table: "Match",
                column: "Teams_TeamBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_Teams_TeamAId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Teams_Teams_TeamBId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "TeamMembership");

            migrationBuilder.DropIndex(
                name: "IX_Match_Teams_TeamAId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Teams_TeamBId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Teams_TeamAId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Teams_TeamBId",
                table: "Match");
        }
    }
}
