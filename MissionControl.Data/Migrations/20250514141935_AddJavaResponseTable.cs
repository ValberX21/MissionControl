using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddJavaResponseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JavaResponse",
                columns: table => new
                {
                    JavaResponseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavaResponse", x => x.JavaResponseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavaResponse");
        }
    }
}
