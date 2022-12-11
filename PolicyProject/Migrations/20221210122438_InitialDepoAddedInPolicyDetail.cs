using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyProject.Migrations
{
    public partial class InitialDepoAddedInPolicyDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InitialDeposite",
                table: "PolicyDetails",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialDeposite",
                table: "PolicyDetails");
        }
    }
}
