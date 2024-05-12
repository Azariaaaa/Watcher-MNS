using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchMNS.Migrations
{
    /// <inheritdoc />
    public partial class LateMissModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "LateMiss",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "LateMiss");
        }
    }
}
