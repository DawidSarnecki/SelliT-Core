using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using SelliT.Data.Products;

namespace SelliT.Data.Invoices
{

    public class InvoiceElement
    {
        #region Constructor

        public InvoiceElement()
        {
        }

        #endregion Constructor

        #region Properties

        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        [Required]
        public int ProductID{ get; set; }
        [Required]
        public int PositionNumber { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [DefaultValue(null)]
        public DateTime ModifyDate { get; set; }
        [DefaultValue(null)]
        public DateTime RemoveDate { get; set; }

        #endregion Properties


        #region Navigation Properties

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

        #endregion  Navigation Properties


    }
}
