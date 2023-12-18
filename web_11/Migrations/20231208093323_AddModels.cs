using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firmas",
                columns: table => new
                {
                    firma_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firma_adi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmas", x => x.firma_id);
                });

            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    sehir_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sehir_adi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.sehir_id);
                });

            migrationBuilder.CreateTable(
                name: "Havalimanis",
                columns: table => new
                {
                    havalimani_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    havalimani_adi = table.Column<string>(type: "text", nullable: false),
                    sehir_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Havalimanis", x => x.havalimani_id);
                    table.ForeignKey(
                        name: "FK_Havalimanis_Sehirs_sehir_id",
                        column: x => x.sehir_id,
                        principalTable: "Sehirs",
                        principalColumn: "sehir_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sefers",
                columns: table => new
                {
                    sefer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kalkis_saati = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    varis_saati = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sefer_fiati = table.Column<decimal>(type: "numeric", nullable: false),
                    kalkis_havalimani_id = table.Column<int>(type: "integer", nullable: false),
                    varis_havalimani_id = table.Column<int>(type: "integer", nullable: false),
                    firma_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sefers", x => x.sefer_id);
                    table.ForeignKey(
                        name: "FK_Sefers_Firmas_firma_id",
                        column: x => x.firma_id,
                        principalTable: "Firmas",
                        principalColumn: "firma_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sefers_Havalimanis_kalkis_havalimani_id",
                        column: x => x.kalkis_havalimani_id,
                        principalTable: "Havalimanis",
                        principalColumn: "havalimani_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sefers_Havalimanis_varis_havalimani_id",
                        column: x => x.varis_havalimani_id,
                        principalTable: "Havalimanis",
                        principalColumn: "havalimani_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyon",
                columns: table => new
                {
                    rezervasyon_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sefer_id = table.Column<int>(type: "integer", nullable: false),
                    rezervasyonTipi = table.Column<int>(type: "integer", nullable: false),
                    koltuk_sayisi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyon", x => x.rezervasyon_id);
                    table.ForeignKey(
                        name: "FK_Rezervasyon_Sefers_sefer_id",
                        column: x => x.sefer_id,
                        principalTable: "Sefers",
                        principalColumn: "sefer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Havalimanis_sehir_id",
                table: "Havalimanis",
                column: "sehir_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyon_sefer_id",
                table: "Rezervasyon",
                column: "sefer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_firma_id",
                table: "Sefers",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_kalkis_havalimani_id",
                table: "Sefers",
                column: "kalkis_havalimani_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefers_varis_havalimani_id",
                table: "Sefers",
                column: "varis_havalimani_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervasyon");

            migrationBuilder.DropTable(
                name: "Sefers");

            migrationBuilder.DropTable(
                name: "Firmas");

            migrationBuilder.DropTable(
                name: "Havalimanis");

            migrationBuilder.DropTable(
                name: "Sehirs");
        }
    }
}
