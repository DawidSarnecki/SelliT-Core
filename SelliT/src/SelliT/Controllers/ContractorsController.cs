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
    public class ContractorsController : Controller
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
        /// Returns An array of a default number of Json-serialized objects representing the last inserted items.
        
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }

        /// GET: api/items/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// Returns An array of {n} Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = GetSampleItems().OrderByDescending(i => i.CreateDate).Take(n);
            return new JsonResult(items, DefaultJsonSettings);
        }
        #endregion


        #region Private Members
        /// Generate a sample array of source Items to emulate a database (for testing purposes only).
        /// Param:  name="num" The number of items to generate: default is 100
        /// Returns: a defined number of mock items (for testing purpose only)
        private List<ContractorViewModel> GetSampleItems(int num = 100)
        {
            List<ContractorViewModel> list = new List<ContractorViewModel>();
            DateTime date = new DateTime(2017, 01, 07).AddDays(-num);
            for (int id = 1; id <= num; id++)
            {
                date = date.AddDays(1);
                list.Add(new ContractorViewModel()
                {
                    Id = id,
                    Name = String.Format("Contractor {0} Name", id),
                    Nip = String.Format("{0}00-000-00-00", id),
                    CreateDate = date
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
        private int DefaultNumberOfItems
        {
            get
            {
                return 5;
            }
        }

        /// Returns the maximum number using the API methods retrieving item lists.
        private int MaxNumberOfItems
        {
            get
            {
                return 100;
            }
        }
        #endregion


    }
}
