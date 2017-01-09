using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SelliT.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class InvoiceViewModel
    {
        #region Constructor
        public InvoiceViewModel()
        {
        }
        #endregion Constructor
           
        #region Properties
        public string ID { get; set; }
        public string ContractorID { get; set; }
        public string PayForm { get; set; }
        [DefaultValue(0)]
        public bool IsPaid { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ModifydDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion Properties
    }
}


