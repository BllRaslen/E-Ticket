using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRezervasyonType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rezervasyonTipi",
                table: "Rezervasyon",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "rezervasyonTipi",
                table: "Rezervasyon",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
