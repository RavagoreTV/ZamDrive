using Microsoft.EntityFrameworkCore.Migrations;

namespace ZamkDb.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PickUpPoint1",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PickUpPoint2",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpPoint3",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZealandLocation",
                table: "Courses",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpPoint1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PickUpPoint2",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PickUpPoint3",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ZealandLocation",
                table: "Courses");
        }
    }
}
