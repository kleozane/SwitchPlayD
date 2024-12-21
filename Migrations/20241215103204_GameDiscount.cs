using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlayD.Migrations
{
    /// <inheritdoc />
    public partial class GameDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Games",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Games");
        }
    }
}
