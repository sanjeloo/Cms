using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addnews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "newsLetters");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    Abstract = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoBanner = table.Column<string>(maxLength: 50, nullable: true),
                    PageName = table.Column<string>(maxLength: 100, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 100, nullable: true),
                    MetaKeyWord = table.Column<string>(maxLength: 100, nullable: true),
                    MetaImage = table.Column<string>(maxLength: 50, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile = table.Column<string>(maxLength: 250, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsLetter");

            migrationBuilder.CreateTable(
                name: "newsLetters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsLetters", x => x.Id);
                });
        }
    }
}
