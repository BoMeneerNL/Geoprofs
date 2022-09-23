using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class AddedVerlofids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verlof",
                table: "Verlof");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Verlof");

            migrationBuilder.AddColumn<int>(
                name: "VerlofID",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "MedewerkerID",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verlof",
                table: "Verlof",
                column: "VerlofID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verlof",
                table: "Verlof");

            migrationBuilder.DropColumn(
                name: "VerlofID",
                table: "Verlof");

            migrationBuilder.DropColumn(
                name: "MedewerkerID",
                table: "Verlof");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Verlof",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verlof",
                table: "Verlof",
                column: "Naam");
        }
    }
}
