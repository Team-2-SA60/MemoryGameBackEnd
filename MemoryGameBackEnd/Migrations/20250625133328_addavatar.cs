using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryGameBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class addavatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Games",
                newName: "Date");

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImage",
                table: "Users",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Games",
                newName: "StartTime");
        }
    }
}
