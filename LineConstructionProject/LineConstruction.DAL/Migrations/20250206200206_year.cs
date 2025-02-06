using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class year : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperineceYear",
                table: "OurTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperineceYear",
                table: "OurTeams");
        }
    }
}
