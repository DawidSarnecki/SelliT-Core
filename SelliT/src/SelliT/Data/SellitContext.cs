using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SelliT.Data.Invoices;
using SelliT.Data.Contractors;
using SelliT.Data.Products;
using SelliT.Data.Users;

namespace SelliT.Data
{
    public class SellitContext : DbContext
    {
        #region Constructor

        public SellitContext(DbContextOptions<SellitContext>  options) : base(options)
        {
        }

        #endregion Constructor

        #region Properties

        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceElement> InvoiceElement { get; set; }
        public DbSet<AppUser> User { get; set; }

        #endregion Properties


        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Contractor>().ToTable("Contractor");
            modelBuilder.Entity<Contractor>().Property(c => c.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(e => e.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<Invoice>().Property(i => i.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<InvoiceElement>().ToTable("InvoiceElement");
            modelBuilder.Entity<InvoiceElement>().Property(e => e.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<AppUser>().ToTable("User");
            modelBuilder.Entity<AppUser>().Property(e => e.ID).ValueGeneratedOnAdd();
        }

        #endregion Methods


    }
}
