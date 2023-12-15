using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAgregatorWeb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("bus_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "way",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("way_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    IsWeekend = table.Column<bool>(type: "boolean", nullable: false),
                    Holiday = table.Column<int>(type: "integer", nullable: false),
                    WeekDay = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    FeelsLike = table.Column<double>(type: "double precision", nullable: false),
                    Wind = table.Column<double>(type: "double precision", nullable: false),
                    Precipitation = table.Column<double>(type: "double precision", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    TrafficJams = table.Column<int>(type: "integer", nullable: true),
                    Join = table.Column<int>(type: "integer", nullable: false),
                    Left = table.Column<int>(type: "integer", nullable: false),
                    BusId = table.Column<int>(type: "integer", nullable: false),
                    BusCount = table.Column<int>(type: "integer", nullable: false),
                    WayId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("trip_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "trip_bus_fkey",
                        column: x => x.BusId,
                        principalTable: "bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trip_way_fkey",
                        column: x => x.WayId,
                        principalTable: "way",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trip_BusId",
                table: "trip",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_trip_WayId",
                table: "trip",
                column: "WayId");

            migrationBuilder.CreateIndex(
                name: "name_unique",
                table: "way",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "way");
        }
    }
}
