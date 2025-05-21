using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe2.Migrations
{
    /// <inheritdoc />
    public partial class Gruppe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndexInfo_Colorinfos_ColorInfoID",
                table: "IndexInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantinfos_IndexInfo_IndexInfoID",
                table: "Plantinfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndexInfo",
                table: "IndexInfo");

            migrationBuilder.RenameTable(
                name: "IndexInfo",
                newName: "IndexInfos");

            migrationBuilder.RenameIndex(
                name: "IX_IndexInfo_ColorInfoID",
                table: "IndexInfos",
                newName: "IX_IndexInfos_ColorInfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndexInfos",
                table: "IndexInfos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IndexInfos_Colorinfos_ColorInfoID",
                table: "IndexInfos",
                column: "ColorInfoID",
                principalTable: "Colorinfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantinfos_IndexInfos_IndexInfoID",
                table: "Plantinfos",
                column: "IndexInfoID",
                principalTable: "IndexInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndexInfos_Colorinfos_ColorInfoID",
                table: "IndexInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantinfos_IndexInfos_IndexInfoID",
                table: "Plantinfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndexInfos",
                table: "IndexInfos");

            migrationBuilder.RenameTable(
                name: "IndexInfos",
                newName: "IndexInfo");

            migrationBuilder.RenameIndex(
                name: "IX_IndexInfos_ColorInfoID",
                table: "IndexInfo",
                newName: "IX_IndexInfo_ColorInfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndexInfo",
                table: "IndexInfo",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_IndexInfo_Colorinfos_ColorInfoID",
                table: "IndexInfo",
                column: "ColorInfoID",
                principalTable: "Colorinfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantinfos_IndexInfo_IndexInfoID",
                table: "Plantinfos",
                column: "IndexInfoID",
                principalTable: "IndexInfo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
