using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class Try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionnalStatusId",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client",
                column: "ProfessionnalStatusId",
                principalTable: "ProfessionnalStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionnalStatusId",
                table: "Client",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_ProfessionnalStatus_ProfessionnalStatusId",
                table: "Client",
                column: "ProfessionnalStatusId",
                principalTable: "ProfessionnalStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");
        }
    }
}
