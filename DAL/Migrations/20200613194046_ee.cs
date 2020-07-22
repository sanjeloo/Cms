using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "AspNetUsers");
        }
    }
}
