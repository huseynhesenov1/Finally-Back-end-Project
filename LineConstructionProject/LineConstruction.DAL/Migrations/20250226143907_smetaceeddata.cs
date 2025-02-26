using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class smetaceeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be10629f-0508-451a-8fv1-0e905705e1f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7908c741-39d1-45e4-91db-79c7d8bbf4d1", "AQAAAAIAAYagAAAAEN6R+wuNU54Du2Ev9hrcxjI5ECyh8Emizgs3U8imYvso8HmN8bh1y8GfkDQEpX1xnQ==", "d18e6586-af94-45c1-9fa9-5d0a9e94c460" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be30629f-0508-461a-8fa1-0e905705e1f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7f6c273-57b2-49a1-a343-74dc3093ad2e", "AQAAAAIAAYagAAAAEJPfdRyZ6PFiuCB9bagonMaeS2VBh8rTd0ItbH6CNelo1Y1rTRh+fwCR99BSzcUNcQ==", "784fc36a-ccef-49ba-b6e8-6d37896539c8" });

            migrationBuilder.InsertData(
                table: "Foundations",
                columns: new[] { "Id", "ArmaturePrice", "ConcretePrice", "ConcretePriceEmployer", "DrillingPriceEmployer", "KhamitPrice", "KhamitPriceEmployer" },
                values: new object[] { 1, 150m, 200m, 180m, 100m, 50m, 60m });

            migrationBuilder.InsertData(
                table: "Masonries",
                columns: new[] { "Id", "CementPrice", "SandPrice", "StonePrice", "WorkerSalary" },
                values: new object[] { 1, 50m, 40m, 80m, 200m });

            migrationBuilder.InsertData(
                table: "Plasters",
                columns: new[] { "Id", "CementPrice", "SandPrice", "WorkerSalaryForArea" },
                values: new object[] { 1, 70m, 50m, 120m });

            migrationBuilder.InsertData(
                table: "Roofs",
                columns: new[] { "Id", "NailPrice", "ReykaPrice", "RoofingPrice", "WoodPrice", "WorkerSalaryForArea" },
                values: new object[] { 1, 30m, 90m, 180m, 120m, 150m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foundations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Masonries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plasters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roofs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be10629f-0508-451a-8fv1-0e905705e1f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e8ead6f-46ee-488c-aab0-22d2234e44ae", "AQAAAAIAAYagAAAAEBjPe6F97oiccYEoNlT/71DbVM+a/D05s24wUdip7OmWH0vTwYPuZAuPFJMJ640MMA==", "34e9d5cb-a837-4d26-841e-7aed68b3dd84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be30629f-0508-461a-8fa1-0e905705e1f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c4047ee-1b82-4f9d-a0f6-d0fbf29645a4", "AQAAAAIAAYagAAAAEDhCDVoC9m14RClshpPfTh7xFuGVyKwVsv6xSzAFTBW5VaEBYXr+kR9QRa1HkV3R+Q==", "4112fc1e-9a30-4064-818a-b66359b1bd3a" });
        }
    }
}
