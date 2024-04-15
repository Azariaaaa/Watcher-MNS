using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LateMissDoc_LateMisse_LateMissId",
                table: "LateMissDoc");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMisse_Client_ClientId",
                table: "LateMisse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMisse",
                table: "LateMisse");

            migrationBuilder.RenameTable(
                name: "LateMisse",
                newName: "LateMiss");

            migrationBuilder.RenameIndex(
                name: "IX_LateMisse_ClientId",
                table: "LateMiss",
                newName: "IX_LateMiss_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMiss",
                table: "LateMiss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LateMiss_Client_ClientId",
                table: "LateMiss",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMissDoc_LateMiss_LateMissId",
                table: "LateMissDoc",
                column: "LateMissId",
                principalTable: "LateMiss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LateMiss_Client_ClientId",
                table: "LateMiss");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMissDoc_LateMiss_LateMissId",
                table: "LateMissDoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LateMiss",
                table: "LateMiss");

            migrationBuilder.RenameTable(
                name: "LateMiss",
                newName: "LateMisse");

            migrationBuilder.RenameIndex(
                name: "IX_LateMiss_ClientId",
                table: "LateMisse",
                newName: "IX_LateMisse_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LateMisse",
                table: "LateMisse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LateMissDoc_LateMisse_LateMissId",
                table: "LateMissDoc",
                column: "LateMissId",
                principalTable: "LateMisse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMisse_Client_ClientId",
                table: "LateMisse",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
