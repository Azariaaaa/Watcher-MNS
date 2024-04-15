using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LateMissStatusId",
                table: "LateMiss",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatusId",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LateMiss_LateMissStatusId",
                table: "LateMiss",
                column: "LateMissStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentStatusId",
                table: "Document",
                column: "DocumentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusId",
                table: "Document",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LateMiss_LateMissStatus_LateMissStatusId",
                table: "LateMiss",
                column: "LateMissStatusId",
                principalTable: "LateMissStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMiss_LateMissStatus_LateMissStatusId",
                table: "LateMiss");

            migrationBuilder.DropIndex(
                name: "IX_LateMiss_LateMissStatusId",
                table: "LateMiss");

            migrationBuilder.DropIndex(
                name: "IX_Document_DocumentStatusId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "LateMissStatusId",
                table: "LateMiss");

            migrationBuilder.DropColumn(
                name: "DocumentStatusId",
                table: "Document");
        }
    }
}
