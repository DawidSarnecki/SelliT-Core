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
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string BuyerNip { get; set; }
        public string BuyerAddress { get; set; }
        public string SellerName { get; set; }
        public string SellerNip { get; set; }
        public string SellerAddress { get; set; }
        public string Description { get; set; }
        public string PayForm { get; set; }
        [DefaultValue(0)]
        public bool IsPaid { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime X_RemoveDate { get; set; }
        #endregion Properties
    }
}


