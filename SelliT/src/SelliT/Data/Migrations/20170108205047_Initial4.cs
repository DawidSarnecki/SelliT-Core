using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SelliT.Data.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsSeller = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Contractor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyerID = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: false),
                    PayForm = table.Column<int>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    SellerID = table.Column<int>(nullable: false),
                    totalToPay = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceElement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    InvoiceIdID = table.Column<int>(nullable: true),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    Vat = table.Column<double>(nullable: false),
                    VatValue = table.Column<double>(nullable: false),
                    value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceElement_Invoice_InvoiceIdID",
                        column: x => x.InvoiceIdID,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_InvoiceIdID",
                table: "InvoiceElement",
                column: "InvoiceIdID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "InvoiceElement");

            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
