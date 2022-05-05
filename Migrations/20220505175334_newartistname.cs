using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inlamningsuppgift_Marie.Migrations
{
    public partial class newartistname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Albums");
        }
    }
}
