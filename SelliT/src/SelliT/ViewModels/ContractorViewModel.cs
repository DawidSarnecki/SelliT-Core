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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime X_RemoveDate { get; set; }
        #endregion Properties
    }
}


