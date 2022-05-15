using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class testar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistEntityArtistId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistEntityArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistEntityArtistId",
                table: "Albums");

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

            migrationBuilder.AddColumn<int>(
                name: "ArtistEntityArtistId",
                table: "Albums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistEntityArtistId",
                table: "Albums",
                column: "ArtistEntityArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistEntityArtistId",
                table: "Albums",
                column: "ArtistEntityArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId");
        }
    }
}
