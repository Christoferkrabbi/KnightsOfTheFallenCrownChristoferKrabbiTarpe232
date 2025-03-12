using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnightsOfTheFallenCrown.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migger28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    BattlefieldDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "BattlefieldID",
                table: "FilesToDatabase");
        }
    }
}
