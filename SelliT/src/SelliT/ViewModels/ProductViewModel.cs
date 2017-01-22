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
        public int TaxRate { get; set; }
        public double PriceWithTax
        {
            get
            {
                if (TaxRate != 0)
                {
                    return (Math.Round(Price + TaxRate * Price / 100,2));
                }
                else
                {
                    return (Math.Round(Price,2));
                }
            }     
        }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion Properties
    }
}
