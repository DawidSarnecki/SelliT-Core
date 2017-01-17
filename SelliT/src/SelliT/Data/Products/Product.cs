using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SelliT.Data.Invoices;

namespace SelliT.Data.Products
{ 
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
        [DefaultValue("szt.")]
        public string Unit { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DefaultValue(23)]
        public int TaxRate { get; set; }
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
