using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelliT.Data._Migrations
{
    public partial class ChangedIDType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceElement_Invoice_InvoiceID1",
                table: "InvoiceElement");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceElement_Product_ProductID1",
                table: "InvoiceElement");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceElement_InvoiceID1",
                table: "InvoiceElement");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceElement_ProductID1",
                table: "InvoiceElement");

            migrationBuilder.DropColumn(
                name: "InvoiceID1",
                table: "InvoiceElement");

            migrationBuilder.DropColumn(
                name: "ProductID1",
                table: "InvoiceElement");

            migrationBuilder.AlterColumn<string>(
                name: "ProductID",
                table: "InvoiceElement",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceID",
                table: "InvoiceElement",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_InvoiceID",
                table: "InvoiceElement",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ProductID",
                table: "InvoiceElement",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceElement_Invoice_InvoiceID",
                table: "InvoiceElement",
                column: "InvoiceID",
                principalTable: "Invoice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceElement_Product_ProductID",
                table: "InvoiceElement",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceElement_Invoice_InvoiceID",
                table: "InvoiceElement");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceElement_Product_ProductID",
                table: "InvoiceElement");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceElement_InvoiceID",
                table: "InvoiceElement");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceElement_ProductID",
                table: "InvoiceElement");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "InvoiceElement",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "InvoiceElement",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceID1",
                table: "InvoiceElement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductID1",
                table: "InvoiceElement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_InvoiceID1",
                table: "InvoiceElement",
                column: "InvoiceID1");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceElement_ProductID1",
                table: "InvoiceElement",
                column: "ProductID1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceElement_Invoice_InvoiceID1",
                table: "InvoiceElement",
                column: "InvoiceID1",
                principalTable: "Invoice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceElement_Product_ProductID1",
                table: "InvoiceElement",
                column: "ProductID1",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
