using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelliT.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProductViewModel
    {
        #region Constructor
        public ProductViewModel()
        {
        }
        #endregion Constructor

        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public string TaxRate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion Properties
    }
}
