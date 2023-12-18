using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class asasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Havalimanis_sehir_id",
                table: "Havalimanis",
                column: "sehir_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Havalimanis_Sehirs_sehir_id",
                table: "Havalimanis",
                column: "sehir_id",
                principalTable: "Sehirs",
                principalColumn: "sehir_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Havalimanis_Sehirs_sehir_id",
                table: "Havalimanis");

            migrationBuilder.DropIndex(
                name: "IX_Havalimanis_sehir_id",
                table: "Havalimanis");
        }
    }
}
