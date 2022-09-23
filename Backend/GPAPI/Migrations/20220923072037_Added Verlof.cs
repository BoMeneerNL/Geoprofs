using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class AddedVerlof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verlof",
                columns: table => new
                {
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Van = table.Column<uint>(type: "INTEGER", nullable: false),
                    Tot = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verlof", x => x.Naam);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verlof");
        }
    }
}
