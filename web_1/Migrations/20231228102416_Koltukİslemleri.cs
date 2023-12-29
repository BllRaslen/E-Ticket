using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace web_1.Migrations
{
    /// <inheritdoc />
    public partial class Koltukİslemleri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Koltuklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kod = table.Column<string>(type: "text", nullable: false),
                    durum = table.Column<bool>(type: "boolean", nullable: false),
                    rezervasyon_id = table.Column<int>(type: "integer", nullable: false),
                    Firmarezervasyon_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koltuklar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koltuklar_Rezervasyons_Firmarezervasyon_id",
                        column: x => x.Firmarezervasyon_id,
                        principalTable: "Rezervasyons",
                        principalColumn: "rezervasyon_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koltuklar_Firmarezervasyon_id",
                table: "Koltuklar",
                column: "Firmarezervasyon_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koltuklar");
        }
    }
}
