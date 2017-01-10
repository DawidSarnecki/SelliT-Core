using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelliT.ViewModels;
using Newtonsoft.Json;
using SelliT.Data;
using SelliT.Data.Invoices;
using Nelibur.ObjectMapper;

namespace SelliT.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceElementsController : Controller
    {
        #region Private Fields
        private readonly SellitContext DbContext;
        #endregion Private Fields

        #region Constructor
        public InvoiceElementsController(SellitContext context)
        {
            // Dependency Injetion
            DbContext = context;
        }
        #endregion Constructor

        #region RESTful Conventions
        /// GET api/InvoiceElementss/
        /// Returns: Nothing: this method will raise a HttpNotFound HTTP exception
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// GET: api/InvoiceElementss/{id}
        /// ROUTING TYPE: attribute-based
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var InvoiceElements = DbContext.InvoiceElement
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return new JsonResult(TinyMapper.Map<InvoiceElementsViewModel>(InvoiceElements), DefaultJsonSettings);
        }
        #endregion

        #region Attribute-based Routing
        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// Returns: An array of a default number of Json-serialized objects representing the last inserted items.
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
            if (n > MaxNumberOfInvoiceElementss) n = MaxNumberOfInvoiceElementss;
            var invoiceElements = DbContext.InvoiceElement
                .OrderByDescending(i => i.CreateDate)
                .Take(n).ToArray();
            return new JsonResult(ToInvoiceElementsViewModelList(invoiceElements), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/InvoiceElementss/GetAllElements
        /// ROUTING TYPE: attribute-based
        /// Returns: An array of Json-serialized objects representing the last inserted items.
        /// 
        [HttpGet("GetAllElements")]
        public IActionResult GetAllElements()
        {
            var invoiceElements = DbContext.InvoiceElement.ToArray();

            return new JsonResult(ToInvoiceElementsViewModelList(invoiceElements), DefaultJsonSettings);

        }

        #endregion

        #region Private Members
    
        /// Maps a collection of InvoiceElements entities into a list of ItemViewModel objects.
        /// param name="InvoiceElementss": An IEnumerable collection of item entities
        /// Returns a mapped list of InvoiceElementsViewModel objects
        private List<InvoiceElementsViewModel> ToInvoiceElementsViewModelList(IEnumerable<InvoiceElement> InvoiceElementss)
        {
            var lst = new List<InvoiceElementsViewModel>();
            foreach (var i in InvoiceElementss)
                lst.Add(TinyMapper.Map<InvoiceElementsViewModel>(i));
            return lst;
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

        /// Returns the default number of InvoiceElementss to retrieve when using the parameterless overloads of the API methods retrieving item lists.
        private int DefaultNumberOfIvoices
        {
            get
            {
                return 5;
            }
        }

        /// Returns the maximum number using the API methods retrieving item lists.
        private int MaxNumberOfInvoiceElementss
        {
            get
            {
                return 100;
            }
        }
        #endregion
    }
}



      