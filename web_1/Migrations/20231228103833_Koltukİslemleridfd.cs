using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class Koltukİslemleridfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklar_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Koltuklar",
                table: "Koltuklar");

            migrationBuilder.RenameTable(
                name: "Koltuklar",
                newName: "Koltuklars");

            migrationBuilder.RenameIndex(
                name: "IX_Koltuklar_Firmarezervasyon_id",
                table: "Koltuklars",
                newName: "IX_Koltuklars_Firmarezervasyon_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Koltuklars",
                table: "Koltuklars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklars_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklars",
                column: "Firmarezervasyon_id",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuklars_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Koltuklars",
                table: "Koltuklars");

            migrationBuilder.RenameTable(
                name: "Koltuklars",
                newName: "Koltuklar");

            migrationBuilder.RenameIndex(
                name: "IX_Koltuklars_Firmarezervasyon_id",
                table: "Koltuklar",
                newName: "IX_Koltuklar_Firmarezervasyon_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Koltuklar",
                table: "Koltuklar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuklar_Rezervasyons_Firmarezervasyon_id",
                table: "Koltuklar",
                column: "Firmarezervasyon_id",
                principalTable: "Rezervasyons",
                principalColumn: "rezervasyon_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
