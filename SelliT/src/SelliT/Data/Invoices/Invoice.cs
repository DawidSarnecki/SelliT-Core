using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using SelliT.Data.Contractors;

namespace SelliT.Data.Invoices
{
    public enum PayForm
    {
        przelew, gotówka, karta
    }

    public class Invoice
    {

        #region Constructor
        public Invoice()
        {

        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        [DefaultValue(1)]
        public int SellerID { get; set; }
        [Required]
        [DefaultValue(1)]
        public int BuyerID { get; set; }
        [DefaultValue(1)]
        public PayForm PayForm { get; set; } 
        [Required]
        public double totalToPay { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
        [DefaultValue(null)]
        public DateTime PaidDate { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        [DefaultValue(null)]
        public DateTime RemoveDate { get; set; }
        #endregion

        #region Related Properties
        ///Seller, Buyer: this properties will be loaded on first use using EF's Lazy-Loading feature.
        [ForeignKey("SellerID")]
        public virtual Contractor Seller { get; set; }
        [ForeignKey("BuyerID")]
        public virtual Contractor Buyer { get; set; }
        
        /// Current Invoice's Position list: this property will be loaded on first use using EF's Lazy-Loading feature.
        public virtual List<Position> Positions { get; set; }
        #endregion

    }
}
