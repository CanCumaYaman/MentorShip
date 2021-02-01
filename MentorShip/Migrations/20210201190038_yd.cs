using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorShip.Migrations
{
    public partial class yd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Resumes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Resumes",
                nullable: true);
        }
    }
}
