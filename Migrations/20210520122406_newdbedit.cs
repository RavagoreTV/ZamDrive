using Microsoft.EntityFrameworkCore.Migrations;

namespace ZamkDb.Migrations
{
    public partial class newdbedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ChosenPickUpPoint",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ChosenPickUpPoint",
                table: "Bookings");
        }
    }
}
