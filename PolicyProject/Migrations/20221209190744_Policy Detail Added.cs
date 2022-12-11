using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PolicyProject.Migrations
{
    public partial class PolicyDetailAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyDetails",
                columns: table => new
                {
                    PolicyDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    TermsPerYear = table.Column<int>(nullable: false),
                    TermsAmount = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true, defaultValue: "pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyDetails", x => x.PolicyDetailId);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyDetails_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_PolicyId",
                table: "PolicyDetails",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyDetails_UserId",
                table: "PolicyDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyDetails");
        }
    }
}
