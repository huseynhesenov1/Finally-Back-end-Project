using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class foundationn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foundations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcretePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArmaturePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhamitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrillingPriceEmployer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhamitPriceEmployer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConcretePriceEmployer = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foundations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foundations");
        }
    }
}
