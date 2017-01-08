using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SelliT.Data.Contractors;

namespace SelliT.Data.Invoices
{

    public class InvoiceElement
    {
        #region Constructor
        public InvoiceElement()
        {
        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string InvoiceId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double value { get;}
        [Required]
        public double Vat { get; set; }
        [Required]
        public double VatValue { get;}
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion

        #region Related Properties
        ///Seller, Buyer: this properties will be loaded on first use using EF's Lazy-Loading feature.
        [ForeignKey("InvoiceIdID")]
        public virtual Invoice Invoice { get; set; }
        #endregion


    }
}
