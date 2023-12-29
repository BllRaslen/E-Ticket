using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class Rezervizasyon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sefer_fiati",
                table: "Sefers");

            migrationBuilder.AddColumn<double>(
                name: "sefer_fiati",
                table: "Rezervasyons",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sefer_fiati",
                table: "Rezervasyons");

            migrationBuilder.AddColumn<double>(
                name: "sefer_fiati",
                table: "Sefers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
