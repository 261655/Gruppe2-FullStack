using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe2.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indexinfos_Colorinfos_ColorInfoID",
                table: "Indexinfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantinfos_Indexinfos_IndexInfoID",
                table: "Plantinfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Indexinfos",
                table: "Indexinfos");

            migrationBuilder.RenameTable(
                name: "Indexinfos",
                newName: "IndexInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Indexinfos_ColorInfoID",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Indexinfos");

            migrationBuilder.RenameIndex(
                name: "IX_IndexInfo_ColorInfoID",
                table: "Indexinfos",
                newName: "IX_Indexinfos_ColorInfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Indexinfos",
                table: "Indexinfos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Indexinfos_Colorinfos_ColorInfoID",
                table: "Indexinfos",
                column: "ColorInfoID",
                principalTable: "Colorinfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantinfos_Indexinfos_IndexInfoID",
                table: "Plantinfos",
                column: "IndexInfoID",
                principalTable: "Indexinfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
