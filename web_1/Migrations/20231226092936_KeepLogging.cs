using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class KeepLogging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "kalkis_tarihi",
                table: "Sefers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "varis_tarihi",
                table: "Sefers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "KeepLoggedIn",
                table: "Persons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kalkis_tarihi",
                table: "Sefers");

            migrationBuilder.DropColumn(
                name: "varis_tarihi",
                table: "Sefers");

            migrationBuilder.DropColumn(
                name: "KeepLoggedIn",
                table: "Persons");
        }
    }
}
