using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SelliT.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ContractorViewModel
    {
        #region Constructor
        public ContractorViewModel()
        {
        }
        #endregion Constructor

        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PersonToInvoice { get; set; }
        public string Address {
            get
            {
                if (ApartmentNumber != null)
                {
                    return Street + " " + Number + " / "+ ApartmentNumber +", " + ZipCode + " " + City;
                }
                else
                    return Street + " " + Number + ", " + ZipCode + " " + City;
            }
        }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion Properties
    }
}


