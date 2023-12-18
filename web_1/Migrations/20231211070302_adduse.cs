using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class adduse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "Persons",
                newName: "gmail");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Persons",
                newName: "sifre");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Persons",
                newName: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gmail",
                table: "Persons",
                newName: "Gmail");

            migrationBuilder.RenameColumn(
                name: "sifre",
                table: "Persons",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Persons",
                newName: "AdminId");
        }
    }
}
