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
        public static void Initialize(SellitContext context)
        {
            /*
            
            // Look for any Contractors.
            if (context.Contractor.Any())
            {
                return;   // DB has been seeded
            }

#if DEBUG
            var num = 100;  // create 100 sample contracors
            for (int id = 1; id <= num; id++)
            {
                DbContext.Contractor.Add(GetSampleContractor(authorId, num - id, new DateTime(2015, 12, 31).AddDays(-num)));
            }
#endif




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

            

            var invoicElements = new InvoiceElement[]
            {
                new InvoiceElement
                {
                    InvoiceId = 1,
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
                    InvoiceId = 1,
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
                    InvoiceId = 2,
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
                    InvoiceId = 3,
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
            
          
            
            var invoices = new Invoice[]
            {
                new Invoice
                {
                    Number = "2015/A/55555",
                    BuyerID = 2,
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
                    BuyerID =3,
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
                    BuyerID = 3,
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
                    BuyerID = 4,
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
            
            context.SaveChanges(); 
            
            }
        }

        private Contractor GetSampleContractor(string authorId, int viewCount, DateTime createdDate)
        {
            return new Contractor()
            {
                Name = "Carson",
                Nip = "000-000-00-00",
                Street = "Kowalska",
                Number = "15A",
                ZipCode = "15-150",
                City = "Sopot",
                PersonToInvoice = "Kowalska J.",
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now

                UserId = authorId,
                Title = String.Format("Item {0} Title", id),
                Description = String.Format("This is a sample description for item {0}: Lorem ipsum dolor sit amet.", id),
                Notes = "This is a sample record created by the Code-First Configuration class",
                ViewCount = viewCount,
                CreatedDate = createdDate,
                LastModifiedDate = createdDate
            };
            */
        }





    }
          
}