using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyProject.Migrations
{
    public partial class policyProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    InitialDeposite = table.Column<double>(nullable: false),
                    PolicyType = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    TermsPerYear = table.Column<int>(nullable: false),
                    TermsAmount = table.Column<double>(nullable: false),
                    Interest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Pan = table.Column<string>(nullable: true),
                    EmployerType = table.Column<string>(nullable: true),
                    EmployerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
