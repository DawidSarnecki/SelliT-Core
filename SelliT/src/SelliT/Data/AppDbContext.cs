using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SelliT.Data.Invoices;
using SelliT.Data.Contractors;

namespace SelliT.Data
{
    public class AppDbContext : DbContext
    {
        #region Constructor

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion Constructor

        #region Properties
        public DbSet<Contractor> Items { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceElement> InvoiceElement { get; set; }
        #endregion Properties


        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contractor>().ToTable("Contractor");
            modelBuilder.Entity<Contractor>().Property(c => c.Id).ValueGeneratedOnAdd();
       
            modelBuilder.Entity<Invoice>().ToTable("Invoice");
            modelBuilder.Entity<Invoice>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Invoice>().HasMany(i => i.InvoiceElements).WithOne(c => c.Invoice).HasForeignKey(k => k.InvoiceId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InvoiceElement>().ToTable("InvoiceElement");
            modelBuilder.Entity<InvoiceElement>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<InvoiceElement>().HasOne(e => e.Invoice);        }
        #endregion Methods

    }
}
