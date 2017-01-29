using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SelliT.Data.Invoices;
using SelliT.Data.Products;


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
        public string Number { get; set; }
        public string ContractorID { get; set; }
        public string PayForm { get; set; }
        public bool IsPaid { get; set; }
        public string UserId { get; set; }
        public ContractorViewModel Contractor { get; set; }
        public IList<InvoiceElementsViewModel> Elements { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ModifydDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public string test
        {
            get { return "test"; }
        }

        #endregion Properties
    }
}


