using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnightsOfTheFallenCrown.Data.Migrations
{
    /// <inheritdoc />
    public partial class migger2 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
