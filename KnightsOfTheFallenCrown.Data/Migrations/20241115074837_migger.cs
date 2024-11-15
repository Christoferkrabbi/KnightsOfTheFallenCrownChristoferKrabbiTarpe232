using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnightsOfTheFallenCrown.Data.Migrations
{
    /// <inheritdoc />
    public partial class migger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    KnightID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Knights",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KnightName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnightDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnightHealth = table.Column<int>(type: "int", nullable: false),
                    KnightLevel = table.Column<int>(type: "int", nullable: false),
                    KnightXP = table.Column<int>(type: "int", nullable: false),
                    KnightXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    KnightStatus = table.Column<int>(type: "int", nullable: false),
                    KnightType = table.Column<int>(type: "int", nullable: false),
                    KnightPerk = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knights", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "Knights");
        }
    }
}
