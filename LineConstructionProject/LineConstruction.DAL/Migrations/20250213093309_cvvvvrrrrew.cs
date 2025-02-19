using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cvvvvrrrrew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddedCV_Vacancies_VacancyId",
                table: "AddedCV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddedCV",
                table: "AddedCV");

            migrationBuilder.RenameTable(
                name: "AddedCV",
                newName: "AddedCVs");

            migrationBuilder.RenameIndex(
                name: "IX_AddedCV_VacancyId",
                table: "AddedCVs",
                newName: "IX_AddedCVs_VacancyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddedCVs",
                table: "AddedCVs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddedCVs_Vacancies_VacancyId",
                table: "AddedCVs",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddedCVs_Vacancies_VacancyId",
                table: "AddedCVs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddedCVs",
                table: "AddedCVs");

            migrationBuilder.RenameTable(
                name: "AddedCVs",
                newName: "AddedCV");

            migrationBuilder.RenameIndex(
                name: "IX_AddedCVs_VacancyId",
                table: "AddedCV",
                newName: "IX_AddedCV_VacancyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddedCV",
                table: "AddedCV",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddedCV_Vacancies_VacancyId",
                table: "AddedCV",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
