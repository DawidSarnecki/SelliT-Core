using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelliT.Data._Migrations
{
    public partial class ContractorIDType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractorID",
                table: "Invoice",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Invoice",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ContractorID",
                table: "Invoice",
                nullable: false);
        }
    }
}
