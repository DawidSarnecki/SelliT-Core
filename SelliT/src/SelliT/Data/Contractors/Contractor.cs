using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using SelliT.Data.Invoices;

namespace SelliT.Data.Contractors
{
    public class Contractor
    {
        #region Constructor
        public Contractor()
        {

        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Nip { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string ApartmentNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PersonToInvoice { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsSeller { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion

        #region Related Properties
        /// A list of ivoice wrote where this contractor is a seller or byer
        // public virtual List<Invoice> Invoice { get; set; }
        #endregion Related Properties
}
}
