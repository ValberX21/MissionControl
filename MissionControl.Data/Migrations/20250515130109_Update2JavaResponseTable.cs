using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update2JavaResponseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalReference",
                table: "JavaResponse",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalReference",
                table: "JavaResponse");
        }
    }
}
