using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelliT.Data._Migrations
{
    public partial class InitialCreate : Migration
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
                    ContractorID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    PayForm = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
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
                    Name = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
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
                    InvoiceID = table.Column<int>(nullable: false),
                    InvoiceID1 = table.Column<string>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    PositionNumber = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductID1 = table.Column<string>(nullable: true),
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
                        name: "FK_InvoiceElement_Invoice_InvoiceID1",
                        column: x => x.InvoiceID1,
                        principalTable: "Invoice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceElement_Product_ProductID1",
                        column: x => x.ProductID1,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ContractorID",
                table: "InvoiceElement",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_InvoiceID1",
                table: "InvoiceElement",
                column: "InvoiceID1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ProductID1",
                table: "InvoiceElement",
                column: "ProductID1");
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
