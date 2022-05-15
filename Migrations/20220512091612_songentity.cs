using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class songentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongLength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumsAlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumsAlbumId",
                        column: x => x.AlbumsAlbumId,
                        principalTable: "Albums",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumsAlbumId",
                table: "Songs",
                column: "AlbumsAlbumId");

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

            migrationBuilder.DropTable(
                name: "Songs");

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
    }
}
