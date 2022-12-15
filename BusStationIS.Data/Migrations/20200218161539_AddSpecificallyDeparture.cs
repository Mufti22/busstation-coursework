using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusStationIS.Data.Migrations
{
    public partial class AddSpecificallyDeparture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificallyDepartures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificallyDepartures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificallyDepartures_Departures_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Departures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificallyDepartures_DepartureId",
                table: "SpecificallyDepartures",
                column: "DepartureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificallyDepartures");
        }
    }
}
