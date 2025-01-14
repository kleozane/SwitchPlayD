using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlayD.Migrations
{
    /// <inheritdoc />
    public partial class magnetlink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MagnetLink",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MagnetLink",
                table: "Games");
        }
    }
}
