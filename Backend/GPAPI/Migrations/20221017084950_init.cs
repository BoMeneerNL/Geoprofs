using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    MedewerkerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", nullable: true),
                    Wachtwoord = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.MedewerkerID);
                });

            migrationBuilder.CreateTable(
                name: "Authtokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    MedewerkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Expires = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authtokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_Authtokens_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verlof",
                columns: table => new
                {
                    VerlofID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedewerkerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Van = table.Column<uint>(type: "INTEGER", nullable: false),
                    Tot = table.Column<uint>(type: "INTEGER", nullable: false),
                    Status = table.Column<byte>(type: "INTEGER", nullable: false),
                    Reden = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verlof", x => x.VerlofID);
                    table.ForeignKey(
                        name: "FK_Verlof_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "MedewerkerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authtokens_MedewerkerId",
                table: "Authtokens",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Verlof_MedewerkerId",
                table: "Verlof",
                column: "MedewerkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authtokens");

            migrationBuilder.DropTable(
                name: "Verlof");

            migrationBuilder.DropTable(
                name: "Medewerkers");
        }
    }
}
