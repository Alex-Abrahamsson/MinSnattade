using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class lista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumsAlbumId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumsAlbumId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AlbumsAlbumId",
                table: "Songs");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "AlbumsAlbumId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumsAlbumId",
                table: "Songs",
                column: "AlbumsAlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumsAlbumId",
                table: "Songs",
                column: "AlbumsAlbumId",
                principalTable: "Albums",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
