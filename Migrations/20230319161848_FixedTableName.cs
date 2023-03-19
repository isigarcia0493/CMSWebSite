using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebsite.Migrations
{
    public partial class FixedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_Albums_AlbumId",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_images_AlbumId",
                table: "Images",
                newName: "IX_Images_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AlbumId",
                table: "images",
                newName: "IX_images_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_images_Albums_AlbumId",
                table: "images",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
