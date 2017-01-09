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
            if (context.Contractor.Any())
            {
                return;   // DB has been seeded
            }


            var num = 20;  // create 20 sample contractors
            var contractors = new List<Contractor>();
            for (int id = 1; id <= num; id++)
            {
                contractors.Add(GetSampleContractor(num - 1));
            }
            foreach (var item in contractors)
            {
                context.Contractor.Add(item);
            }

            // create 20 sample products
            for (int id = 1; id <= num; id++)
            {
                context.Product.Add(GetSampleProduct(num - id));
                
            }
        }

        private static Product GetSampleProduct(int number)
            {
                return new Product()
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Product {0} Name", number),
                    Price = 100+2*number,
                    CreateDate = DateTime.Now
                };
            }

            private static Contractor GetSampleContractor(int number)
            {
                return new Contractor()
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = String.Format("Contractor {0} Name", number),
                    Nip = "000-000-00-00",
                    Street = "Kowalska",
                    Number = "15A",
                    ZipCode = "15-150",
                    City = "Sopot",
                    PersonToInvoice = "Kowalska J.",
                    CreateDate = DateTime.Now
                };
            }

       
        /*


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



            }





        }*/

    }
    
 }