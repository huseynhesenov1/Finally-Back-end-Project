using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class orderclientresiteric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OurTeams_OurServices_OurServiceId",
                table: "OurTeams");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Orders",
                newName: "Problem");

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientFullName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientPhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OurServiceId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OurTeamId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OurServiceId",
                table: "Orders",
                column: "OurServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OurTeamId",
                table: "Orders",
                column: "OurTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OurServices_OurServiceId",
                table: "Orders",
                column: "OurServiceId",
                principalTable: "OurServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OurTeams_OurTeamId",
                table: "Orders",
                column: "OurTeamId",
                principalTable: "OurTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OurTeams_OurServices_OurServiceId",
                table: "OurTeams",
                column: "OurServiceId",
                principalTable: "OurServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OurServices_OurServiceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OurTeams_OurTeamId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OurTeams_OurServices_OurServiceId",
                table: "OurTeams");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OurServiceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OurTeamId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientFullName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientPhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OurServiceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OurTeamId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Problem",
                table: "Orders",
                newName: "FullName");

            migrationBuilder.AddForeignKey(
                name: "FK_OurTeams_OurServices_OurServiceId",
                table: "OurTeams",
                column: "OurServiceId",
                principalTable: "OurServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
