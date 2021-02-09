using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorShip.Migrations
{
    public partial class gy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Error",
                table: "ErrorMessages",
                newName: "ErrorMessage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "ErrorMessages",
                newName: "Error");
        }
    }
}
