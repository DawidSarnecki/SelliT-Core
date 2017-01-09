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
        public string ID { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string ContractorID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        [DefaultValue(PayForm.przelew)]
        public PayForm PayForm { get; set; } 
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
