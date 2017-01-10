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
    public class InvoicesController : Controller
    {
        #region Private Fields
        private readonly SellitContext DbContext;
        #endregion Private Fields

        #region Constructor
        public InvoicesController(SellitContext context)
        {
            // Dependency Injetion
            DbContext = context;
        }
        #endregion Constructor

        #region RESTful Conventions
        /// GET api/invoices/
        /// Returns: Nothing: this method will raise a HttpNotFound HTTP exception
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// GET: api/invoices/{id}
        /// ROUTING TYPE: attribute-based
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var invoice = DbContext.Invoice
                .Where(i => i.ID == id)
                .FirstOrDefault();
            return new JsonResult(TinyMapper.Map<InvoiceViewModel>(invoice), DefaultJsonSettings);
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
            if (n > MaxNumberOfInvoices) n = MaxNumberOfInvoices;
            var invoices = DbContext.Invoice
                .OrderByDescending(i => i.CreateDate)
                .Take(n).ToArray();
            return new JsonResult(ToInvoiceViewModelList(invoices), DefaultJsonSettings);
        }

        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// Returns: An array of a default number of Json-serialized objects representing the last inserted items.
        /// 

       

        [HttpGet("GetAllDetail")]
        public IActionResult GetAllDetail()
        {
            var invoices = DbContext.Invoice;
            var elements = DbContext.InvoiceElement;
            var invoiceDetail =
                from i in invoices
                join el in elements on i.ID equals el.InvoiceID into ivoiceEl
                select new
                {
                    Invoice = invoices,
                    InvoiceElements = from el2 in ivoiceEl
                                     select el2
                };
            //invoiceDetail.ToArray();
            // foreach (InvoiceElement e in i.InvoiceElements.Where(e => e.InvoiceID
            //JsonResult jsonInvoice, jsonElement;
            foreach (var inv in invoiceDetail)
            {
                foreach (var elem in inv.InvoiceElements)
                {
                    return new JsonResult(ToInvoiceElementViewModelList(inv.InvoiceElements.ToArray()), DefaultJsonSettings);
                }
                return new JsonResult(ToInvoiceViewModelList(inv.Invoice.ToArray()), DefaultJsonSettings);
            }

        }

        [HttpGet("GetAllElements")]
        public IActionResult GetAllElements()
        {
                var invoiceElements = DbContext.InvoiceElement.ToArray();

                return new JsonResult(ToInvoiceElementViewModelList(invoiceElements), DefaultJsonSettings);
     
        }

        #endregion

        #region Private Members
        /// Maps a collection of InvoiceElement entities into a list of InvoiceElementsViewModel objects.
        /// param name=invoiceElements": An IEnumerable collection of item entities
        /// Returns a mapped list of InvoiceElementsViewModel objects
        private List<InvoiceElementsViewModel> ToInvoiceElementViewModelList(IEnumerable<InvoiceElement> invoiceElements)
        {
            var lst = new List<InvoiceElementsViewModel>();
            foreach (var i in invoiceElements)
                lst.Add(TinyMapper.Map<InvoiceElementsViewModel>(i));
            return lst;
        }

        /// Maps a collection of Invoice entities into a list of ItemViewModel objects.
        /// param name="invoices": An IEnumerable collection of item entities
        /// Returns a mapped list of InvoiceViewModel objects
        private List<InvoiceViewModel> ToInvoiceViewModelList(IEnumerable<Invoice> invoices)
        {
            var lst = new List<InvoiceViewModel>();
            foreach (var i in invoices)
                lst.Add(TinyMapper.Map<InvoiceViewModel>(i));
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

      
    }
}
