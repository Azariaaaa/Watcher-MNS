using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
