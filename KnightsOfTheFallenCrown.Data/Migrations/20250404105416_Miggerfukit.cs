using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnightsOfTheFallenCrown.Data.Migrations
{
    /// <inheritdoc />
    public partial class Miggerfukit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "KnightHasDied",
                table: "Knights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KnightWasBorn",
                table: "Knights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAttackName",
                table: "Knights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryAttackPower",
                table: "Knights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAttackName",
                table: "Knights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SecondaryAttackPower",
                table: "Knights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "BattlefieldID",
                table: "FilesToDatabase",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Battlefields",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BattlefieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BattlefieldType = table.Column<int>(type: "int", nullable: false),
                    EnvironmentBoost = table.Column<int>(type: "int", nullable: true),
                    BattlefieldDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Settlements = table.Column<int>(type: "int", nullable: false),
                    TechnicalLevel = table.Column<int>(type: "int", nullable: false),
                    ContinentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battlefields", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battlefields");

            migrationBuilder.DropColumn(
                name: "KnightHasDied",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "KnightWasBorn",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "PrimaryAttackName",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "PrimaryAttackPower",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "SecondaryAttackName",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "SecondaryAttackPower",
                table: "Knights");

            migrationBuilder.DropColumn(
                name: "BattlefieldID",
                table: "FilesToDatabase");
        }
    }
}
