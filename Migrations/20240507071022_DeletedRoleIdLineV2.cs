using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class DeletedRoleIdLineV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: true);
        }
    }
}
