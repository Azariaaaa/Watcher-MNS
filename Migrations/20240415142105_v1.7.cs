using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class v17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Notification_NotificationId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_NotificationId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClientNotification",
                columns: table => new
                {
                    NotificationsId = table.Column<int>(type: "int", nullable: false),
                    clientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientNotification", x => new { x.NotificationsId, x.clientsId });
                    table.ForeignKey(
                        name: "FK_ClientNotification_Client_clientsId",
                        column: x => x.clientsId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientNotification_Notification_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ClientId",
                table: "Training",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RoleId",
                table: "Client",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotification_clientsId",
                table: "ClientNotification",
                column: "clientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Client_ClientId",
                table: "Training",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_Client_ClientId",
                table: "Training");

            migrationBuilder.DropTable(
                name: "ClientNotification");

            migrationBuilder.DropIndex(
                name: "IX_Training_ClientId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Client_RoleId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_NotificationId",
                table: "Client",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Notification_NotificationId",
                table: "Client",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id");
        }
    }
}
