using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetworkBE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeamMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembership_Players_PlayerId",
                table: "TeamMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembership_Teams_TeamId",
                table: "TeamMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembership",
                table: "TeamMembership");

            migrationBuilder.RenameTable(
                name: "TeamMembership",
                newName: "TeamMemberships");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembership_TeamId",
                table: "TeamMemberships",
                newName: "IX_TeamMemberships_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembership_PlayerId",
                table: "TeamMemberships",
                newName: "IX_TeamMemberships_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMemberships",
                table: "TeamMemberships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberships_Players_PlayerId",
                table: "TeamMemberships",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMemberships_Teams_TeamId",
                table: "TeamMemberships",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberships_Players_PlayerId",
                table: "TeamMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMemberships_Teams_TeamId",
                table: "TeamMemberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMemberships",
                table: "TeamMemberships");

            migrationBuilder.RenameTable(
                name: "TeamMemberships",
                newName: "TeamMembership");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberships_TeamId",
                table: "TeamMembership",
                newName: "IX_TeamMembership_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMemberships_PlayerId",
                table: "TeamMembership",
                newName: "IX_TeamMembership_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembership",
                table: "TeamMembership",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembership_Players_PlayerId",
                table: "TeamMembership",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembership_Teams_TeamId",
                table: "TeamMembership",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
