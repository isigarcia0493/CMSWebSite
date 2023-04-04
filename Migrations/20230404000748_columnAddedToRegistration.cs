using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSWebsite.Migrations
{
    public partial class columnAddedToRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistrationId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_RegistrationId",
                table: "Events",
                column: "RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Registrations_RegistrationId",
                table: "Events",
                column: "RegistrationId",
                principalTable: "Registrations",
                principalColumn: "RegistrationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Registrations_RegistrationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RegistrationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RegistrationId",
                table: "Events");
        }
    }
}
