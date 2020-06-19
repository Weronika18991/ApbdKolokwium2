using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApbdKolokwium2.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganizers_Organizers_IdOrganizer",
                table: "EventOrganizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers");

            migrationBuilder.DropIndex(
                name: "IX_EventOrganizers_IdOrganizer",
                table: "EventOrganizers");

            migrationBuilder.DropColumn(
                name: "IdOrganizer",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "IdOrganizer",
                table: "EventOrganizers");

            migrationBuilder.AddColumn<int>(
                name: "IdOrganiser",
                table: "Organizers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdOrganiser",
                table: "EventOrganizers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "IdOrganiser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers",
                columns: new[] { "IdEvent", "IdOrganiser" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "Nickname" },
                values: new object[,]
                {
                    { 1, "Nana" },
                    { 2, "Pipi" },
                    { 3, "LilPipi" },
                    { 4, "Tede" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super imprezka", new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2008, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czadowa impreza", new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2010, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Extra Widowisko", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2015, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mocne Mello", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "IdOrganiser", "Name" },
                values: new object[,]
                {
                    { 1, "MichałX" },
                    { 2, "MacelZ" },
                    { 3, "TomuS" },
                    { 4, "SpayDeer" }
                });

            migrationBuilder.InsertData(
                table: "ArtistEvents",
                columns: new[] { "IdEvent", "IdArtist", "PerformanceDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EventOrganizers",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizers_IdOrganiser",
                table: "EventOrganizers",
                column: "IdOrganiser");

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganizers_Organizers_IdOrganiser",
                table: "EventOrganizers",
                column: "IdOrganiser",
                principalTable: "Organizers",
                principalColumn: "IdOrganiser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganizers_Organizers_IdOrganiser",
                table: "EventOrganizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers");

            migrationBuilder.DropIndex(
                name: "IX_EventOrganizers_IdOrganiser",
                table: "EventOrganizers");

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ArtistEvents",
                keyColumns: new[] { "IdEvent", "IdArtist" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "IdOrganiser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "IdOrganiser",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "IdOrganiser",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "IdOrganiser",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IdOrganiser",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "IdOrganiser",
                table: "EventOrganizers");

            migrationBuilder.AddColumn<int>(
                name: "IdOrganizer",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdOrganizer",
                table: "EventOrganizers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "IdOrganizer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventOrganizers",
                table: "EventOrganizers",
                columns: new[] { "IdEvent", "IdOrganizer" });

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizers_IdOrganizer",
                table: "EventOrganizers",
                column: "IdOrganizer");

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganizers_Organizers_IdOrganizer",
                table: "EventOrganizers",
                column: "IdOrganizer",
                principalTable: "Organizers",
                principalColumn: "IdOrganizer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
