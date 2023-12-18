using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class asas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Havalimanis_Sehirs_sehir_id",
                table: "Havalimanis");

            migrationBuilder.DropForeignKey(
                name: "FK_Sefers_Havalimanis_kalkis_havalimani_id",
                table: "Sefers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sefers_Havalimanis_varis_havalimani_id",
                table: "Sefers");

            migrationBuilder.DropIndex(
                name: "IX_Sefers_kalkis_havalimani_id",
                table: "Sefers");

            migrationBuilder.DropIndex(
                name: "IX_Sefers_varis_havalimani_id",
                table: "Sefers");

            migrationBuilder.DropIndex(
                name: "IX_Havalimanis_sehir_id",
                table: "Havalimanis");

            migrationBuilder.DropColumn(
                name: "kalkis_havalimani_id",
                table: "Sefers");

            migrationBuilder.DropColumn(
                name: "varis_havalimani_id",
                table: "Sefers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "kalkis_havalimani_id",
                table: "Sefers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "varis_havalimani_id",
                table: "Sefers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_kalkis_havalimani_id",
                table: "Sefers",
                column: "kalkis_havalimani_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_varis_havalimani_id",
                table: "Sefers",
                column: "varis_havalimani_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sefers_Havalimanis_kalkis_havalimani_id",
                table: "Sefers",
                column: "kalkis_havalimani_id",
                principalTable: "Havalimanis",
                principalColumn: "havalimani_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sefers_Havalimanis_varis_havalimani_id",
                table: "Sefers",
                column: "varis_havalimani_id",
                principalTable: "Havalimanis",
                principalColumn: "havalimani_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
