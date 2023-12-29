using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class Kolfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id1",
                table: "Koltuklars");

            migrationBuilder.DropIndex(
                name: "IX_Koltuklars_rezervasyon_id1",
                table: "Koltuklars");

            migrationBuilder.DropColumn(
                name: "rezervasyon_id1",
                table: "Koltuklars");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklars_rezervasyon_id",
                table: "Koltuklars",
                column: "rezervasyon_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id",
                table: "Koltuklars",
                column: "rezervasyon_id",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id",
                table: "Koltuklars");

            migrationBuilder.DropIndex(
                name: "IX_Koltuklars_rezervasyon_id",
                table: "Koltuklars");

            migrationBuilder.AddColumn<int>(
                name: "rezervasyon_id1",
                table: "Koltuklars",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklars_rezervasyon_id1",
                table: "Koltuklars",
                column: "rezervasyon_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklars_Rezervasyons_rezervasyon_id1",
                table: "Koltuklars",
                column: "rezervasyon_id1",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
