using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelliT.ViewModels;
using Newtonsoft.Json;
using SelliT.Data;
using SelliT.Data.Contractors;
using Nelibur.ObjectMapper;

namespace SelliT.Controllers
{
    [Route("api/[controller]")]
    public class ContractorsController : Controller
    {
        #region Private Fields
        private SellitContext DbContext;
        #endregion Private Fields
        
        #region Constructor
        public ContractorsController(SellitContext context)
        {
            // Dependency Injetion
            DbContext = context;
        }
        #endregion Constructor



        #region RESTful Conventions
        /// GET api/constructors/
        /// Returns: Nothing: this method will raise a HttpNotFound HTTP exception
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// GET: api/constructors/{id}
        /// ROUTING TYPE: attribute-based
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var contractor = DbContext.Contractor.Where(c => c.ID == id).FirstOrDefault();
            return new JsonResult(TinyMapper.Map<ContractorViewModel>(contractor), DefaultJsonSettings);
        }
        #endregion RESTful Conventions


        #region Attribute-based Routing
        /// GET: api/constructors/GetLatest
        /// ROUTING TYPE: attribute-based
        /// Returns An array of a default number of Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }

        /// GET: api/constructors/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// Returns An array of {n} Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var contracors = DbContext.Contractor.OrderByDescending(i => i.CreateDate).Take(n).ToArray();
            return new JsonResult(ToContractorViewModelList(contracors), DefaultJsonSettings);
        }
        #endregion Attribute-based Routing


        #region Private Members
        /// Maps a collection of Item entities into a list of ItemViewModel objects.
        /// param name="items": An IEnumerable collection of item entities
        /// Returns a mapped list of ContractorViewModel objects
        private List<ContractorViewModel> ToContractorViewModelList(IEnumerable<Contractor> contracors)
        {
            var lst = new List<ContractorViewModel>();
            foreach (var i in contracors)
                lst.Add(TinyMapper.Map<ContractorViewModel>(i));
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
        private int DefaultNumberOfItems
        {
            get
            {
                return 3;
            }
        }

        /// Returns the maximum number using the API methods retrieving item lists.
        private int MaxNumberOfItems
        {
            get
            {
                return 5;
            }
        }
        #endregion Private Members


    }
}
