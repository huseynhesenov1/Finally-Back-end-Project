using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class masonries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masonries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StonePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CementPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SandPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkerSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masonries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masonries");
        }
    }
}
