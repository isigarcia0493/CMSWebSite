using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebsite.Migrations
{
    public partial class albumImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumImageUrl",
                table: "Albums",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Albums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumImageUrl",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Albums");
        }
    }
}
