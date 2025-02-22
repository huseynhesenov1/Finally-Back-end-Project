using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class checkoutadress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "OrderCheckouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "OrderCheckouts");
        }
    }
}
