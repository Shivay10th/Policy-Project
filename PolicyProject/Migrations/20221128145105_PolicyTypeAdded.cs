using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyProject.Migrations
{
    public partial class PolicyTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyType",
                table: "Policy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Policy",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Policy",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyTypeId",
                table: "Policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PolicyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyTypeId",
                table: "Policy",
                column: "PolicyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policy_PolicyType_PolicyTypeId",
                table: "Policy",
                column: "PolicyTypeId",
                principalTable: "PolicyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policy_PolicyType_PolicyTypeId",
                table: "Policy");

            migrationBuilder.DropTable(
                name: "PolicyType");

            migrationBuilder.DropIndex(
                name: "IX_Policy_PolicyTypeId",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "PolicyTypeId",
                table: "Policy");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Policy",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PolicyType",
                table: "Policy",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
