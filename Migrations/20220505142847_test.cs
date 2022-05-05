using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
