using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cw10.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Roles",
                newName: "PK_role");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Products",
                newName: "width");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Products",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Depth",
                table: "Products",
                newName: "depth");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Products",
                newName: "PK_product");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Categories",
                newName: "PK_category");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Accounts",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Accounts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Accounts",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Accounts",
                newName: "FK_role");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Accounts",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "IdAccount",
                table: "Accounts",
                newName: "PK_account");

            migrationBuilder.AlterColumn<decimal>(
                name: "width",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "weight",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "height",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "depth",
                table: "Products",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(5)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.CreateTable(
                name: "Products_Categories",
                columns: table => new
                {
                    FK_category = table.Column<int>(type: "int", nullable: false),
                    FK_product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Categories", x => new { x.FK_category, x.FK_product });
                    table.ForeignKey(
                        name: "FK_Products_Categories_Categories_FK_category",
                        column: x => x.FK_category,
                        principalTable: "Categories",
                        principalColumn: "PK_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Carts",
                columns: table => new
                {
                    FK_account = table.Column<int>(type: "int", nullable: false),
                    FK_product = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Carts", x => new { x.FK_account, x.FK_product });
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Accounts_FK_account",
                        column: x => x.FK_account,
                        principalTable: "Accounts",
                        principalColumn: "PK_account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Carts_Products_FK_product",
                        column: x => x.FK_product,
                        principalTable: "Products",
                        principalColumn: "PK_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts",
                column: "FK_role");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categories_FK_product",
                table: "Products_Categories",
                column: "FK_product");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Carts_FK_product",
                table: "Shopping_Carts",
                column: "FK_product");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_FK_role",
                table: "Accounts",
                column: "FK_role",
                principalTable: "Roles",
                principalColumn: "PK_role",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_FK_role",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Products_Categories");

            migrationBuilder.DropTable(
                name: "Shopping_Carts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_FK_role",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PK_role",
                table: "Roles",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "width",
                table: "Products",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Products",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Products",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "depth",
                table: "Products",
                newName: "Depth");

            migrationBuilder.RenameColumn(
                name: "PK_product",
                table: "Products",
                newName: "IdProduct");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PK_category",
                table: "Categories",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Accounts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Accounts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Accounts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Accounts",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FK_role",
                table: "Accounts",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "PK_account",
                table: "Accounts",
                newName: "IdAccount");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Products",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Products",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Products",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Depth",
                table: "Products",
                type: "float(5)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
