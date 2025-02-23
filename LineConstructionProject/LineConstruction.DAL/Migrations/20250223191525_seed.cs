using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LineConstruction.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_OrderCheckouts_OrderCheckoutId",
                table: "BasketItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "792af7b1-45f7-4238-b547-107355540960", null, "Users", "USERS" },
                    { "8aad637d-42e5-4586-a140-697cd3ee8498", null, "Admin", "ADMIN" },
                    { "a923f5d6-8127-4f92-b34d-91f5a8c6a788", null, "HR", "HR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "be10629f-0508-451a-8fv1-0e905705e1f5", 0, "9e8ead6f-46ee-488c-aab0-22d2234e44ae", "Hr12@lineconstruction.com", true, "Huseyn", "Hesenov", false, null, null, "HR", "AQAAAAIAAYagAAAAEBjPe6F97oiccYEoNlT/71DbVM+a/D05s24wUdip7OmWH0vTwYPuZAuPFJMJ640MMA==", null, false, "34e9d5cb-a837-4d26-841e-7aed68b3dd84", false, "HR" },
                    { "be30629f-0508-461a-8fa1-0e905705e1f5", 0, "0c4047ee-1b82-4f9d-a0f6-d0fbf29645a4", "Admin12@lineconstruction.com", true, "Huseyn", "Hesenov", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEDhCDVoC9m14RClshpPfTh7xFuGVyKwVsv6xSzAFTBW5VaEBYXr+kR9QRa1HkV3R+Q==", null, false, "4112fc1e-9a30-4064-818a-b66359b1bd3a", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a923f5d6-8127-4f92-b34d-91f5a8c6a788", "be10629f-0508-451a-8fv1-0e905705e1f5" },
                    { "8aad637d-42e5-4586-a140-697cd3ee8498", "be30629f-0508-461a-8fa1-0e905705e1f5" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_OrderCheckouts_OrderCheckoutId",
                table: "BasketItems",
                column: "OrderCheckoutId",
                principalTable: "OrderCheckouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_OrderCheckouts_OrderCheckoutId",
                table: "BasketItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "792af7b1-45f7-4238-b547-107355540960");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a923f5d6-8127-4f92-b34d-91f5a8c6a788", "be10629f-0508-451a-8fv1-0e905705e1f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8aad637d-42e5-4586-a140-697cd3ee8498", "be30629f-0508-461a-8fa1-0e905705e1f5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aad637d-42e5-4586-a140-697cd3ee8498");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a923f5d6-8127-4f92-b34d-91f5a8c6a788");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be10629f-0508-451a-8fv1-0e905705e1f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be30629f-0508-461a-8fa1-0e905705e1f5");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_OrderCheckouts_OrderCheckoutId",
                table: "BasketItems",
                column: "OrderCheckoutId",
                principalTable: "OrderCheckouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
