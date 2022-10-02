using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class Authtokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authtokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    MedewerkerID = table.Column<int>(type: "INTEGER", nullable: true),
                    Expires = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authtokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_Authtokens_Medewerkers_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "Medewerkers",
                        principalColumn: "MedewerkerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authtokens_MedewerkerID",
                table: "Authtokens",
                column: "MedewerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authtokens");
        }
    }
}
