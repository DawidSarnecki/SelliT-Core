using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SelliT.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class InvoiceElementsViewModel
    {
        #region Constructor
        public InvoiceElementsViewModel()
        {
        }
        #endregion Constructor

 
        #region Properties

        public string ID { get; set; }
        public string InvoiceID { get; set; }
        public string ProductID { get; set; }
        public ProductViewModel Product { get; set;}
        public int PositionNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }

        #endregion Properties
    }
}






    