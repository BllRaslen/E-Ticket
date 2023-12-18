using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class ads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyon_Sefers_sefer_id",
                table: "Rezervasyon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervasyon",
                table: "Rezervasyon");

            migrationBuilder.RenameTable(
                name: "Rezervasyon",
                newName: "Rezervasyons");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyon_sefer_id",
                table: "Rezervasyons",
                newName: "IX_Rezervasyons_sefer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervasyons",
                table: "Rezervasyons",
                column: "rezervasyon_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyons_Sefers_sefer_id",
                table: "Rezervasyons",
                column: "sefer_id",
                principalTable: "Sefers",
                principalColumn: "sefer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyons_Sefers_sefer_id",
                table: "Rezervasyons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervasyons",
                table: "Rezervasyons");

            migrationBuilder.RenameTable(
                name: "Rezervasyons",
                newName: "Rezervasyon");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervasyons_sefer_id",
                table: "Rezervasyon",
                newName: "IX_Rezervasyon_sefer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervasyon",
                table: "Rezervasyon",
                column: "rezervasyon_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyon_Sefers_sefer_id",
                table: "Rezervasyon",
                column: "sefer_id",
                principalTable: "Sefers",
                principalColumn: "sefer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
