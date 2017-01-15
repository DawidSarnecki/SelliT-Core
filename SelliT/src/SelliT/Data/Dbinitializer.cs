using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SelliT.Data;
using SelliT.Data.Invoices;
using SelliT.Data.Contractors;
using SelliT.Data.Products;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SelliT.Data
{
    public static class DbInitializer
    {

        public static void Initialize(SellitContext context)
        {

            // Look for any Contractors.
            if (context.InvoiceElement.Any())
            {
                return;   // DB has been seeded
            }

            #region New Contractors
            var contractors = new Contractor[]
            {
                new Contractor
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("ContractorName"),
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode = "15-150",
                    City = "Sopot",
                    PersonToInvoice = "Kowalska J.",
                    CreateDate = DateTime.Now
                },
                new Contractor
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("ContractorNam"),
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode = "15-150",
                    City = "Sopot",
                    PersonToInvoice = "Kowalska J.",
                    CreateDate = DateTime.Now
                },
                new Contractor
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("ContractorN"),
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode = "15-150",
                    City = "Sopot",
                    PersonToInvoice = "Kowalska J.",
                    CreateDate = DateTime.Now
                },
                new Contractor
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Contractor"),
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode = "15-150",
                    City = "Sopot",
                    PersonToInvoice = "Kowalska J.",
                    CreateDate = DateTime.Now
                }
            };

            foreach (Contractor c in contractors)
            {
                context.Contractor.Add(c);
            }
            context.SaveChanges();

            #endregion New Contractors

            #region New Products
            var products = new Product[]
            {
                new Product
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Komar"),
                    Price = 100*2,
                    CreateDate = DateTime.Now
                },
                new Product
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Pralka"),
                    Price = 100*3,
                    CreateDate = DateTime.Now
                },
                new Product
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Krzesło"),
                    Price = 100+3,
                    CreateDate = DateTime.Now
                },
                new Product
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Kij"),
                    Price = 100+2,
                    CreateDate = DateTime.Now
                },
                new Product
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Usługa"),
                    Price = 100+2,
                    CreateDate = DateTime.Now
                }
            };

            foreach (Product c in products)
            {
                context.Product.Add(c);
            }
            context.SaveChanges();
            #endregion New Products


            #region New Invoice
            var invoices = new Invoice[]
            {
                new Invoice
                {
                    ID = Guid.NewGuid().ToString(),
                    Number = "2015/A/55555",
                    ContractorID = contractors.Single(i => i.Name =="Contractor").ID.ToString(),
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now
                },
                new Invoice
                {
                    ID = Guid.NewGuid().ToString(),
                    Number = "2015/A/55555",
                    ContractorID = contractors.Single(i => i.Name =="Contractor").ID.ToString(),
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now
                },
                new Invoice
                {
                    ID = Guid.NewGuid().ToString(),
                    Number = "2015/A/55555",
                    ContractorID = contractors.Single(i => i.Name =="ContractorN").ID.ToString(),
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now
                },
                new Invoice
                {
                   ID = Guid.NewGuid().ToString(),
                    Number = "2015/A/55555",
                    ContractorID = contractors.Single(i => i.Name =="ContractorNam").ID.ToString(),
                    CreateDate = DateTime.Now,
                    SaleDate = DateTime. Now,
                    PaymentDate = DateTime.Now
                }
            };
            foreach (Invoice c in invoices)
            {
                context.Invoice.Add(c);
            }
            context.SaveChanges();

            #endregion New Invoice

            #region InvoiceElemnts

            #endregion InvoiceElemnts
            var invoicelements = new InvoiceElement[]
            {
                new InvoiceElement
                {
                    ID = Guid.NewGuid().ToString(),
                    InvoiceID ="06373668-d16f-4c0e-b36b-d39f90dea8b5",
                    ProductID = products.Single(i => i.Name =="Pralka").ID.ToString(),
                    PositionNumber = 1,
                    Quantity = 10,
                    CreateDate =DateTime.Now
                },
                 new InvoiceElement
                {
                    ID = Guid.NewGuid().ToString(),
                     InvoiceID = "06373668-d16f-4c0e-b36b-d39f90dea8b5",
                    ProductID = products.Single(i => i.Name =="Krzesło").ID.ToString(),
                    PositionNumber = 2,
                    Quantity = 10,
                    CreateDate =DateTime.Now
                },
                new InvoiceElement
                {
                    ID = Guid.NewGuid().ToString(),
                     InvoiceID ="06373668-d16f-4c0e-b36b-d39f90dea8b5",
                    ProductID = products.Single(i => i.Name =="Usługa").ID.ToString(),
                    PositionNumber = 3,
                    Quantity = 10,
                    CreateDate =DateTime.Now
                },
                 new InvoiceElement
                {
                    ID = Guid.NewGuid().ToString(),
                     InvoiceID ="06373668-d16f-4c0e-b36b-d39f90dea8b5",
                    ProductID = products.Single(i => i.Name =="Kij").ID.ToString(),
                    PositionNumber = 1,
                    Quantity = 10,
                    CreateDate =DateTime.Now
                }
                };

            foreach (InvoiceElement i in invoicelements)
            {
                context.InvoiceElement.Add(i);
            }
            context.SaveChanges();
        }

    }
}