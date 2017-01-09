using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SelliT.Data;

namespace SelliT.Data._Migrations
{
    [DbContext(typeof(SellitContext))]
    partial class SellitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelliT.Data.Contractors.Contractor", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Nip")
                        .IsRequired();

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<string>("PersonToInvoice")
                        .IsRequired();

                    b.Property<DateTime>("RemoveDate");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.Invoice", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractorID");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsPaid");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<DateTime>("PaidDate");

                    b.Property<int>("PayForm");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<DateTime>("RemoveDate");

                    b.Property<DateTime>("SaleDate");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.InvoiceElement", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContractorID");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("InvoiceID");

                    b.Property<string>("InvoiceID1");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("PositionNumber");

                    b.Property<int>("ProductID");

                    b.Property<string>("ProductID1");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RemoveDate");

                    b.HasKey("ID");

                    b.HasIndex("ContractorID");

                    b.HasIndex("InvoiceID1");

                    b.HasIndex("ProductID1");

                    b.ToTable("InvoiceElement");
                });

            modelBuilder.Entity("SelliT.Data.Products.Product", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RemoveDate");

                    b.Property<int>("TaxRate");

                    b.Property<int>("Unit");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SelliT.Data.Users.AppUser", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsSeller");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.Property<string>("Nip")
                        .IsRequired();

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<string>("PersonToInvoice")
                        .IsRequired();

                    b.Property<DateTime>("RemoveDate");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.InvoiceElement", b =>
                {
                    b.HasOne("SelliT.Data.Contractors.Contractor")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("ContractorID");

                    b.HasOne("SelliT.Data.Invoices.Invoice", "Invoice")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("InvoiceID1");

                    b.HasOne("SelliT.Data.Products.Product", "Product")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("ProductID1");
                });
        }
    }
}
