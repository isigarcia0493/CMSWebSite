using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebsite.Migrations
{
    public partial class CarouselModeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    CarouselId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 100, nullable: false),
                    LongDescription = table.Column<string>(maxLength: 500, nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    DisplayImage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousel", x => x.CarouselId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousel");
        }
    }
}
