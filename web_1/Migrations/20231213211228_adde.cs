using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class adde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sefers_Firmas_firma_id",
                table: "Sefers");

            migrationBuilder.AddForeignKey(
                name: "FK_Sefers_Firmas_firma_id",
                table: "Sefers",
                column: "firma_id",
                principalTable: "Firmas",
                principalColumn: "firma_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sefers_Firmas_firma_id",
                table: "Sefers");

            migrationBuilder.AddForeignKey(
                name: "FK_Sefers_Firmas_firma_id",
                table: "Sefers",
                column: "firma_id",
                principalTable: "Firmas",
                principalColumn: "firma_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
