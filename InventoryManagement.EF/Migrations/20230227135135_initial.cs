using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.EF.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__3213E83FBCF662C9", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__3213E83FBC6EFB5C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supplier__3213E83FB3628338", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password_ = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83F4BFB4D05", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__3213E83F7687ED29", x => x.id);
                    table.ForeignKey(
                        name: "FK__product__categor__4BAC3F29",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order___3213E83FBBC0C596", x => x.id);
                    table.ForeignKey(
                        name: "FK__order___customer__5629CD9C",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    stock_level = table.Column<int>(type: "int", nullable: false),
                    min_stock_level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__3213E83F13658D1B", x => x.id);
                    table.ForeignKey(
                        name: "FK__inventory__produ__5CD6CB2B",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product_supplier",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product___D1EC24BB137521C1", x => new { x.product_id, x.supplier_id });
                    table.ForeignKey(
                        name: "FK__product_s__produ__5070F446",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__product_s__suppl__5165187F",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__022945F640B3A7D5", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK__order_ite__order__59063A47",
                        column: x => x.order_id,
                        principalTable: "order_",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__order_ite__produ__59FA5E80",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_product_id",
                table: "inventory",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order__customer_id",
                table: "order_",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_product_id",
                table: "order_item",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_supplier_supplier_id",
                table: "product_supplier",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "UQ__users__AB6E6164CAB7008D",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__users__F3DBC57233F7AD4E",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "product_supplier");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "order_");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
