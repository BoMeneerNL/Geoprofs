using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    public partial class Addedredenenandstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerID",
                table: "Verlof");

            migrationBuilder.RenameColumn(
                name: "MedewerkerID",
                table: "Verlof",
                newName: "MedewerkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Verlof_MedewerkerID",
                table: "Verlof",
                newName: "IX_Verlof_MedewerkerId");

            migrationBuilder.AlterColumn<int>(
                name: "MedewerkerId",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reden",
                table: "Verlof",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerId",
                table: "Verlof",
                column: "MedewerkerId",
                principalTable: "Medewerkers",
                principalColumn: "MedewerkerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerId",
                table: "Verlof");

            migrationBuilder.DropColumn(
                name: "Reden",
                table: "Verlof");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Verlof");

            migrationBuilder.RenameColumn(
                name: "MedewerkerId",
                table: "Verlof",
                newName: "MedewerkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Verlof_MedewerkerId",
                table: "Verlof",
                newName: "IX_Verlof_MedewerkerID");

            migrationBuilder.AlterColumn<int>(
                name: "MedewerkerID",
                table: "Verlof",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Verlof_Medewerkers_MedewerkerID",
                table: "Verlof",
                column: "MedewerkerID",
                principalTable: "Medewerkers",
                principalColumn: "MedewerkerID");
        }
    }
}
