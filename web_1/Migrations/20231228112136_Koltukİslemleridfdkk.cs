using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class Koltukİslemleridfdkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklars_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklars");

            migrationBuilder.RenameColumn(
                name: "Firmarezervasyon_id",
                table: "Koltuklars",
                newName: "rezervasyon_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Koltuklars_Firmarezervasyon_id",
                table: "Koltuklars",
                newName: "IX_Koltuklars_rezervasyon_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id1",
                table: "Koltuklars",
                column: "rezervasyon_id1",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id1",
                table: "Koltuklars");

            migrationBuilder.RenameColumn(
                name: "rezervasyon_id1",
                table: "Koltuklars",
                newName: "Firmarezervasyon_id");

            migrationBuilder.RenameIndex(
                name: "IX_Koltuklars_rezervasyon_id1",
                table: "Koltuklars",
                newName: "IX_Koltuklars_Firmarezervasyon_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklars_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklars",
                column: "Firmarezervasyon_id",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
