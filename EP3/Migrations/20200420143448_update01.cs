using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EP3.Migrations
{
  public partial class update01 : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Customers",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(maxLength: 200, nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Customers", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "tbl_product",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(nullable: true),
            Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_tbl_product", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Orders",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            OrderDate = table.Column<DateTime>(nullable: false),
            CustomerId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Orders", x => x.Id);
            table.ForeignKey(
                      name: "FK_Orders_Customers_CustomerId",
                      column: x => x.CustomerId,
                      principalTable: "Customers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "OrderDetail",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Quantity = table.Column<double>(nullable: false),
            ItemId = table.Column<int>(nullable: false),
            OrderId = table.Column<int>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_OrderDetail", x => x.Id);
            table.ForeignKey(
                      name: "FK_OrderDetail_tbl_product_ItemId",
                      column: x => x.ItemId,
                      principalTable: "tbl_product",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_OrderDetail_Orders_OrderId",
                      column: x => x.OrderId,
                      principalTable: "Orders",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_OrderDetail_ItemId",
          table: "OrderDetail",
          column: "ItemId");

      migrationBuilder.CreateIndex(
          name: "IX_OrderDetail_OrderId",
          table: "OrderDetail",
          column: "OrderId");

      migrationBuilder.CreateIndex(
          name: "IX_Orders_CustomerId",
          table: "Orders",
          column: "CustomerId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "OrderDetail");

      migrationBuilder.DropTable(
          name: "tbl_product");

      migrationBuilder.DropTable(
          name: "Orders");

      migrationBuilder.DropTable(
          name: "Customers");
    }
  }
}
