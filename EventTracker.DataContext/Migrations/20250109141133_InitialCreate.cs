using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventTracker.DataContext.Migrations
{
    
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxParticipants = table.Column<int>(type: "int", nullable: true),
                    CurrentParticipants = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrizePool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sponsors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreamingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Event_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "Capacity", "City", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, "ZAC du Cornillon Nord", 80000, "Saint-Denis", "Stade de France", "93216" },
                    { 2, "8 Boulevard de Bercy", 20000, "Paris", "Accor Arena", "75012" },
                    { 3, "20 Place des Docteurs Mérieux", 17000, "Lyon", "Halle Tony Garnier", "69007" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Guid", "CurrentParticipants", "Date", "Description", "LocationId", "MaxParticipants", "Name", "PrizePool", "Slug", "Sponsors", "Status", "StreamingUrl", "Tags" },
                values: new object[,]
                {
                    { new Guid("3e8607f7-1c1e-4824-955e-c27b088e95cd"), null, new DateTime(2025, 2, 9, 15, 11, 33, 184, DateTimeKind.Local).AddTicks(9975), "La finale du tournoi mondial de League of Legends, un rendez-vous incontournable pour les fans d'eSport.", 2, null, "League of Legends Finals", "500,000 EUR", "league-of-legends-finals", "[\"Riot Games\",\"Corsair\",\"SteelSeries\"]", "Open", "https://twitch.tv/lol_worlds", "[\"eSport\",\"League of Legends\",\"Worlds\"]" },
                    { new Guid("ec4d0e5a-d7df-43d7-b974-48f9e876a516"), null, new DateTime(2025, 1, 9, 15, 11, 33, 184, DateTimeKind.Local).AddTicks(9897), "Une compétition intergalactique époustouflante où les meilleurs s'affrontent pour dominer l'univers.", 1, null, "Star Reign Championship", "100,000 EUR", "star-reign-championship", "[\"Red Bull\",\"Alienware\",\"Logitech\"]", "Open", "https://twitch.tv/star_reign_championship", "[\"eSport\",\"Galactic\",\"Star Reign\"]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
