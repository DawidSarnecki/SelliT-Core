using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SelliT.Data;

namespace SelliT.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170108195435_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelliT.Data.Contractors.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsSeller");

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

                    b.HasKey("Id");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuyerID");

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

                    b.Property<int>("SellerID");

                    b.Property<double>("totalToPay");

                    b.HasKey("Id");

                    b.HasIndex("BuyerID");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.InvoiceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("InvoiceId")
                        .IsRequired();

                    b.Property<int?>("InvoiceIdID");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("RemoveDate");

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.Property<double>("Vat");

                    b.Property<double>("VatValue");

                    b.Property<double>("value");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceIdID");

                    b.ToTable("InvoiceElement");
                });

            modelBuilder.Entity("SelliT.Data.Invoices.Invoice", b =>
                {
                    b.HasOne("SelliT.Data.Contractors.Contractor", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelliT.Data.Invoices.InvoiceElement", b =>
                {
                    b.HasOne("SelliT.Data.Invoices.Invoice", "Invoice")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("InvoiceIdID");
                });
        }
    }
}
