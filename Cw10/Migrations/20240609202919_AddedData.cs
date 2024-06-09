using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cw10.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "PK_category", "name" },
                values: new object[] { 1, "Test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "PK_product", "depth", "height", "name", "weight", "width" },
                values: new object[] { 1, 0.1m, 0.2m, "TestPName", 0.3m, 0.4m });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PK_role", "name" },
                values: new object[] { 1, "User" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PK_account", "email", "first_name", "FK_role", "last_name", "phone" },
                values: new object[] { 1, "j@k.com", "Jan", 1, "Kowalski", null });

            migrationBuilder.InsertData(
                table: "Products_Categories",
                columns: new[] { "FK_category", "FK_product" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Shopping_Carts",
                columns: new[] { "FK_account", "FK_product", "amount" },
                values: new object[] { 1, 1, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products_Categories",
                keyColumns: new[] { "FK_category", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Shopping_Carts",
                keyColumns: new[] { "FK_account", "FK_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "PK_account",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "PK_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "PK_product",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "PK_role",
                keyValue: 1);
        }
    }
}
