using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAPI.Migrations
{
    /// <inheritdoc />
    public partial class adduserinmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Verlof",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Verlof");
        }
    }
}
