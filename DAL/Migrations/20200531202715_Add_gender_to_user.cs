using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Add_gender_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");
        }
    }
}
