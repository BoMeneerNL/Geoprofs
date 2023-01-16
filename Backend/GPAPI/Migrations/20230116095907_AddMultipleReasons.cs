using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleReasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reden",
                table: "Verlof",
                newName: "RedenVerzoek");

            migrationBuilder.AddColumn<string>(
                name: "RedenAntwoord",
                table: "Verlof",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedenAntwoord",
                table: "Verlof");

            migrationBuilder.RenameColumn(
                name: "RedenVerzoek",
                table: "Verlof",
                newName: "Reden");
        }
    }
}
