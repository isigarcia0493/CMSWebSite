using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebsite.Migrations
{
    public partial class ICollectionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormMessages_AspNetUsers_UserId",
                table: "FormMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registrations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FormMessages",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormMessages_AspNetUsers_UserId",
                table: "FormMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormMessages_AspNetUsers_UserId",
                table: "FormMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Registrations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FormMessages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_FormMessages_AspNetUsers_UserId",
                table: "FormMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AspNetUsers_UserId",
                table: "Registrations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
