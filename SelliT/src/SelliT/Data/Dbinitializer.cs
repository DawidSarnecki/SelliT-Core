using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SelliT.Data;
using SelliT.Data.Invoices;
using SelliT.Data.Contractors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SelliT.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Look for any Contractors.
            if (context.Contractor.Any())
            {
                return;   // DB has been seeded
            }

            var contractors = new Contractor[]
            {
                new Contractor
                {
                    Name = "Carson",
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode ="15-150",
                    City = "Sopot",
                    PersonToInvoice ="Kowalska J.",
                    IsSeller = true,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Contractor
                {
                    Name = "Wojen",
                    Nip = "000-000-00-00",
                    Street = "Wowalska",
                    Number = "15A",
                    ZipCode ="15-150",
                    City = "Sopot",
                    PersonToInvoice ="Zowalska J.",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Contractor
                {
                    Name = "Maxi",
                    Nip = "000-000-00-00",
                    Street = "Anamed",
                    Number = "10A",
                    ZipCode ="15-150",
                    City = "Warszwwa",
                    PersonToInvoice ="Alska J.",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                new Contractor
                {
                    Name = "Zaxi",
                    Nip = "000-000-00-00",
                    Street = "Medora",
                    Number = "10A",
                    ZipCode ="15-150",
                    City = "Kilece",
                    PersonToInvoice ="Zomber J.",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                }
            };

            foreach (Contractor c in contractors)
            {
                context.Contractor.Add(c);
            }
            context.SaveChanges();

            /*

            var invoicElements = new InvoiceElement[]
            {
                new InvoiceElement
                {
                    InvoiceId = "1",
                    Quantity = 10,
                    Unit = "szt",
                    Price = 15,
                    value = 150,
                    Vat = 23,
                    VatValue = 517.5,
                    CreateDate =DateTime.Now,
                    ModifyDate =DateTime.Now
                },
                new InvoiceElement
                {
                    InvoiceId = "1",
                    Quantity = 10,
                    Unit = "szt",
                    Price = 15,
                    value = 150,
                    Vat = 23,
                    VatValue = 517.5,
                    CreateDate =DateTime.Now,
                    ModifyDate =DateTime.Now
                },
                new InvoiceElement
                {
                    InvoiceId = "2",
                    Quantity = 10,
                    Unit = "szt",
                    Price = 15,
                    value = 150,
                    Vat = 23,
                    VatValue = 517.5,
                    CreateDate =DateTime.Now,
                    ModifyDate =DateTime.Now
                },
                new InvoiceElement
                {
                    InvoiceId = "3",
                    Quantity = 10,
                    Unit = "szt",
                    Price = 15,
                    value = 150,
                    Vat = 23,
                    VatValue = 517.5,
                    CreateDate =DateTime.Now,
                    ModifyDate =DateTime.Now
                }
            };

            foreach (InvoiceElement i in invoicElements)
            {
                context.InvoiceElement.Add(i);
            }
            context.SaveChanges();
            */

            var invoices = new Invoice[]
            {
                new Invoice
                {
                    Number = "2015/A/55555",
                    SellerID = contractors.Single(s => s.IsSeller == true).Id,
                    BuyerID = contractors.SingleOrDefault(s=> s.IsSeller == false).Id,
                    PayForm = PayForm.gotówka,
                    totalToPay = 10,
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                 new Invoice
                {
                    Number = "2/A/55555",
                    SellerID = contractors.Single(s => s.IsSeller == true).Id,
                    BuyerID = contractors.SingleOrDefault(s=> s.IsSeller == false).Id,
                    PayForm = PayForm.karta,
                    totalToPay = 1000,
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                  new Invoice
                {
                    Number = "5/A/55555",
                    SellerID = contractors.Single(s => s.IsSeller == true).Id,
                    BuyerID = contractors.SingleOrDefault(s=> s.IsSeller == false).Id,
                    PayForm = PayForm.karta,
                    totalToPay = 100000,
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                },
                  new Invoice
                {
                    Number = "1505/A/55555",
                    SellerID = contractors.Single(s => s.IsSeller == true).Id,
                    BuyerID = contractors.SingleOrDefault(s=> s.IsSeller == false).Id,
                    PayForm = PayForm.karta,
                    totalToPay = 1000,
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now,
                    ModifyDate = DateTime.Now
                }
            };

            foreach (Invoice i in invoices)
            {
                context.Invoice.Add(i);
            }
            context.SaveChanges(); 
        }
              
    }
          
}