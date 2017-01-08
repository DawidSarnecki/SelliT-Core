using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelliT.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Contractor_SellerID",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_SellerID",
                table: "Invoice");

            migrationBuilder.AddColumn<double>(
                name: "VatValue",
                table: "InvoiceElement",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "InvoiceElement",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "Contractor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VatValue",
                table: "InvoiceElement");

            migrationBuilder.DropColumn(
                name: "value",
                table: "InvoiceElement");

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "Contractor",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SellerID",
                table: "Invoice",
                column: "SellerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Contractor_SellerID",
                table: "Invoice",
                column: "SellerID",
                principalTable: "Contractor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
