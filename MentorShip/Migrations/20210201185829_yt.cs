using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorShip.Migrations
{
    public partial class yt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    HighSchool = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    MyProperty = table.Column<string>(nullable: true),
                    ForeignLanguages = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: true),
                    Hobbies = table.Column<string>(nullable: true),
                    Sid = table.Column<int>(nullable: false),
                    Mid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
