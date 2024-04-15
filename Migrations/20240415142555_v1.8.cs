using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class v18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMiss_LateMissStatus_LateMissStatusId",
                table: "LateMiss");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Client_ClientId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_ClientId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Training");

            migrationBuilder.RenameColumn(
                name: "LateMissStatusId",
                table: "LateMiss",
                newName: "lateMissStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMiss_LateMissStatusId",
                table: "LateMiss",
                newName: "IX_LateMiss_lateMissStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "lateMissStatusId",
                table: "LateMiss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ClientTraining",
                columns: table => new
                {
                    TrainingsId = table.Column<int>(type: "int", nullable: false),
                    clientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTraining", x => new { x.TrainingsId, x.clientsId });
                    table.ForeignKey(
                        name: "FK_ClientTraining_Client_clientsId",
                        column: x => x.clientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTraining_Training_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTraining_clientsId",
                table: "ClientTraining",
                column: "clientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusId",
                table: "Document",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LateMiss_LateMissStatus_lateMissStatusId",
                table: "LateMiss",
                column: "lateMissStatusId",
                principalTable: "LateMissStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentStatus_DocumentStatusId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_LateMiss_LateMissStatus_lateMissStatusId",
                table: "LateMiss");

            migrationBuilder.DropTable(
                name: "ClientTraining");

            migrationBuilder.RenameColumn(
                name: "lateMissStatusId",
                table: "LateMiss",
                newName: "LateMissStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LateMiss_lateMissStatusId",
                table: "LateMiss",
                newName: "IX_LateMiss_LateMissStatusId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LateMissStatusId",
                table: "LateMiss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "Document",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ClientId",
                table: "Training",
                column: "ClientId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Client_ClientId",
                table: "Training",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
