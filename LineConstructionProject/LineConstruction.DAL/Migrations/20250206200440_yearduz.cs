using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class yearduz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExperineceYear",
                table: "OurTeams",
                newName: "ExperienceYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExperienceYear",
                table: "OurTeams",
                newName: "ExperineceYear");
        }
    }
}
