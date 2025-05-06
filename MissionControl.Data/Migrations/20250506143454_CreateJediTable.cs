using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateJediTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:access_level", "restricted,full,council_only")
                .Annotation("Npgsql:Enum:jedi_rank", "youngling,padawan,knight,master,grand_master");

            migrationBuilder.CreateTable(
                name: "JediKnight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JediName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    LightsaberColor = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    AccessLevel = table.Column<int>(type: "integer", nullable: false),
                    LastAccessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDarkSideSuspected = table.Column<bool>(type: "boolean", nullable: false),
                    PlanetOrigin = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JediKnight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RocketType = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    MasterApprove = table.Column<string>(type: "text", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JediKnight");

            migrationBuilder.DropTable(
                name: "Mission");
        }
    }
}
