using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelliT.ViewModels;
using Newtonsoft.Json;

namespace SelliT.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController
    {
        /// GET api/invoices/GetLatest/{n}
        /// Returns: An array of {n} Json-serialized objects representingthe last inserted items.</returns>
        [HttpGet("GetLatest/{num}")]
        public JsonResult GetLatest(int num)
        {
            var arr = new List<InvoiceViewModel>();
            for (int i = 1; i <= num; i++) arr.Add(new InvoiceViewModel()
            {
                Id = i,
                BuyerName = String.Format("Invoice {0} BuyerName", i),
                BuyerAddress = String.Format("Invoice {0} BuyerAddress", i),
                BuyerNip = String.Format("{0}00-000-00-00", i),
                SellerName = String.Format("Invoice {0} BuyerName", i),
                SellerAddress = String.Format("Invoice {0} BuyerAddress", i),
                SellerNip = String.Format("{0}00-000-00-00", i),
                Description = String.Format("Invoice {0} Description", i),
                PayForm = "gotówka"
            });
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
            return new JsonResult(arr, settings);
        }
    }
}
