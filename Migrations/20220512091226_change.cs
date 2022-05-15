using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "AlbumEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistId",
                table: "AlbumEntity",
                newName: "IX_AlbumEntity_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumEntity",
                table: "AlbumEntity",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumEntity_Artists_ArtistId",
                table: "AlbumEntity",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumEntity_Artists_ArtistId",
                table: "AlbumEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumEntity",
                table: "AlbumEntity");

            migrationBuilder.RenameTable(
                name: "AlbumEntity",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumEntity_ArtistId",
                table: "Albums",
                newName: "IX_Albums_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
