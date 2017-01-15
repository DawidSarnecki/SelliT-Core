using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelliT.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Nip = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    PersonToInvoice = table.Column<string>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ContractorID = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    PayForm = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    TaxRate = table.Column<int>(nullable: false),
                    Unit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsSeller = table.Column<bool>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nip = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    PersonToInvoice = table.Column<string>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceElement",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ContractorID = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    InvoiceID = table.Column<string>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PositionNumber = table.Column<int>(nullable: false),
                    ProductID = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceElement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceElement_Contractor_ContractorID",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceElement_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceElement_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ContractorID",
                table: "InvoiceElement",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_InvoiceID",
                table: "InvoiceElement",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ProductID",
                table: "InvoiceElement",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceElement");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
