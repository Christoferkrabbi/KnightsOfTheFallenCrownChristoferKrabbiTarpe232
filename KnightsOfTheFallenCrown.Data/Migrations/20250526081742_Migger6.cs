using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnightsOfTheFallenCrown.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migger6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TechnicalLevel",
                table: "Battlefields",
                newName: "DifficultyLevel");

            migrationBuilder.AddColumn<int>(
                name: "BattlefieldType",
                table: "FilesToDatabase",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FilesToDatabase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "FilesToDatabase",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BattlefieldType",
                table: "FilesToDatabase");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FilesToDatabase");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "FilesToDatabase");

            migrationBuilder.RenameColumn(
                name: "DifficultyLevel",
                table: "Battlefields",
                newName: "TechnicalLevel");
        }
    }
}
