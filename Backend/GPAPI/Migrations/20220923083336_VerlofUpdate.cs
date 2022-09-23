using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class VerlofUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MedewerkerID",
                table: "Verlof",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Verlof_MedewerkerID",
                table: "Verlof",
                column: "MedewerkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerID",
                table: "Verlof",
                column: "MedewerkerID",
                principalTable: "Medewerkers",
                principalColumn: "MedewerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerID",
                table: "Verlof");

            migrationBuilder.DropIndex(
                name: "IX_Verlof_MedewerkerID",
                table: "Verlof");

            migrationBuilder.AlterColumn<int>(
                name: "MedewerkerID",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
