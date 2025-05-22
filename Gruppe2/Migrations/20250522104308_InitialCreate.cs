using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colorinfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Red = table.Column<float>(type: "REAL", nullable: false),
                    Green = table.Column<float>(type: "REAL", nullable: false),
                    Blue = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colorinfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dateinfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Month = table.Column<int>(type: "INTEGER", nullable: false),
                    Day = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dateinfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PollenRegistreringer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypeOfPollen = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenRegistreringer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IndexInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    IndexDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ColorInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IndexInfos_Colorinfos_ColorInfoID",
                        column: x => x.ColorInfoID,
                        principalTable: "Colorinfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantinfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    InSeason = table.Column<bool>(type: "INTEGER", nullable: false),
                    IndexInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantinfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plantinfos_IndexInfos_IndexInfoID",
                        column: x => x.IndexInfoID,
                        principalTable: "IndexInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollenResponses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateInfoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantInfoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollenResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PollenResponses_Dateinfos_DateInfoID",
                        column: x => x.DateInfoID,
                        principalTable: "Dateinfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PollenResponses_Plantinfos_PlantInfoID",
                        column: x => x.PlantInfoID,
                        principalTable: "Plantinfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndexInfos_ColorInfoID",
                table: "IndexInfos",
                column: "ColorInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Plantinfos_IndexInfoID",
                table: "Plantinfos",
                column: "IndexInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponses_DateInfoID",
                table: "PollenResponses",
                column: "DateInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PollenResponses_PlantInfoID",
                table: "PollenResponses",
                column: "PlantInfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollenRegistreringer");

            migrationBuilder.DropTable(
                name: "PollenResponses");

            migrationBuilder.DropTable(
                name: "Dateinfos");

            migrationBuilder.DropTable(
                name: "Plantinfos");

            migrationBuilder.DropTable(
                name: "IndexInfos");

            migrationBuilder.DropTable(
                name: "Colorinfos");
        }
    }
}
