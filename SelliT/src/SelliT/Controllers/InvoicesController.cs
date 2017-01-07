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
    public class InvoicesController : Controller
    {
        #region RESTful Conventions
        /// GET api/invoices/
        /// Returns: Nothing: this method will raise a HttpNotFound HTTP exception
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// GET: api/items/{id}
        /// ROUTING TYPE: attribute-based
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(GetSampleItems()
                .Where(i => i.Id == id)
                .FirstOrDefault(),
                DefaultJsonSettings);
        }
        #endregion


        #region Attribute-based Routing
        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// </summary>
        /// <returns>An array of a default number of Json-serialized objects representing the last inserted items.</returns>
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfIvoices);
        }

        /// GET: api/items/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// Returns An array of {n} Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfInvoices) n = MaxNumberOfInvoices;
            var items = GetSampleItems().OrderByDescending(i => i.CreateDate).Take(n);
            return new JsonResult(items, DefaultJsonSettings);
        }
        #endregion


        #region Private Members
        /// Generate a sample array of source Items to emulate a database (for testing purposes only).
        /// Param:  name="num" The number of items to generate: default is 100
        /// Returns: a defined number of mock items (for testing purpose only)
        private List<InvoiceViewModel> GetSampleItems(int num = 100)
        {
            List<InvoiceViewModel> list = new List<InvoiceViewModel>();
            DateTime date = new DateTime(2015, 12, 31).AddDays(-num);
            for (int id = 1; id <= num; id++)
            {
                date = date.AddDays(1);
                list.Add(new InvoiceViewModel()
                {
                    Id = id,
                    BuyerName = String.Format("Invoice {0} BuyerName", id),
                    BuyerAddress = String.Format("Invoice {0} BuyerAddress", id),
                    BuyerNip = String.Format("{0}00-000-00-00", id),
                    SellerName = String.Format("Invoice {0} BuyerName", id),
                    SellerAddress = String.Format("Invoice {0} BuyerAddress", id),
                    SellerNip = String.Format("{0}00-000-00-00", id),
                    Description = String.Format("Invoice {0} Description", id),
                    PayForm = "gotówka"
                });
            }
            return list;
        }

        /// Returns a suitable JsonSerializerSettings object that can be used to generate the JsonResult return value for this Controller's methods.
        private JsonSerializerSettings DefaultJsonSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
            }
        }

        /// Returns the default number of invoices to retrieve when using the parameterless overloads of the API methods retrieving item lists.
        private int DefaultNumberOfIvoices
        {
            get
            {
                return 5;
            }
        }

        /// Returns the maximum number using the API methods retrieving item lists.
        private int MaxNumberOfInvoices
        {
            get
            {
                return 100;
            }
        }
        #endregion

        #region GetLatestOld/{num}
        /// Old GetLatest method
        /// GET api/invoices/GetLatestOd/{n}
        /// Returns: An array of {n} Json-serialized objects representingthe last inserted items.</returns> 
        [HttpGet("GetLatestOld/{num}")]
        public JsonResult GetLatestOld(int num)
        {
            var array = new List<InvoiceViewModel>();
            for (int i = 1; i <= num; i++) array.Add(new InvoiceViewModel()
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
            return new JsonResult(array, settings);
        }
        #endregion
    }
}
