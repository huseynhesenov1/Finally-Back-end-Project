using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cvvvvrrrre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddedCVs",
                table: "AddedCVs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AddedCVs");

            migrationBuilder.RenameTable(
                name: "AddedCVs",
                newName: "AddedCV");

            migrationBuilder.AddColumn<int>(
                name: "VacancyId",
                table: "AddedCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddedCV",
                table: "AddedCV",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AddedCV_VacancyId",
                table: "AddedCV",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddedCV_Vacancies_VacancyId",
                table: "AddedCV",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddedCV_Vacancies_VacancyId",
                table: "AddedCV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddedCV",
                table: "AddedCV");

            migrationBuilder.DropIndex(
                name: "IX_AddedCV_VacancyId",
                table: "AddedCV");

            migrationBuilder.DropColumn(
                name: "VacancyId",
                table: "AddedCV");

            migrationBuilder.RenameTable(
                name: "AddedCV",
                newName: "AddedCVs");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AddedCVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddedCVs",
                table: "AddedCVs",
                column: "Id");
        }
    }
}
