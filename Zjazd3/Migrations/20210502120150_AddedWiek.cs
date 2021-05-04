using Microsoft.EntityFrameworkCore.Migrations;

namespace Zjazd3.Migrations
{
    public partial class AddedWiek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wiek",
                table: "MyUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wiek",
                table: "MyUsers");
        }
    }
}
