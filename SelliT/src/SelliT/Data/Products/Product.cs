using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SelliT.Data.Invoices;

namespace SelliT.Data.Products
{
    public enum TaxRate
    {
         Vat23 = 23,
         Vat8 = 8,
         Vat7 = 7,
         Vat4 = 4,
         ZW = 0
    }
    public enum Unit
    {
        szt, kpl, l, kg
    }

    public class Product
    {
        #region Constructor

        public Product()
        {

        }

        #endregion Constructor

        #region Properties

        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DefaultValue(Unit.szt)]
        public Unit Unit { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DefaultValue(TaxRate.Vat23)]
        public TaxRate TaxRate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [DefaultValue(null)]
        public DateTime ModifyDate { get; set; }
        [DefaultValue(null)]
        public DateTime RemoveDate { get; set; }

        #endregion Properties

        #region Navigation Properties

        public ICollection<InvoiceElement> InvoiceElements { get; set; }

        #endregion Navigation Properties
    }

}
