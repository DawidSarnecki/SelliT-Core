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
        private AppDbContext DbContext;
        #endregion Private Fields
        
        #region Constructor
        public ContractorsController(AppDbContext context)
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

        /// GET: api/items/{id}
        /// ROUTING TYPE: attribute-based
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contractor = DbContext.Contractor.Where(c => c.Id == id).FirstOrDefault();
            return new JsonResult(TinyMapper.Map<ContractorViewModel>(contractor), DefaultJsonSettings);
        }
        #endregion


        #region Attribute-based Routing

        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatestOld(DefaultNumberOfItems);
        }

        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var contracors = DbContext.Contractor.OrderByDescending(i => i.CreateDate).Take(n).ToArray();
            return new JsonResult(ToContractorViewModelList(contracors), DefaultJsonSettings);
        }


        /// <summary>
        /// GET: api/items/GetLatest
        /// ROUTING TYPE: attribute-based
        /// Returns An array of a default number of Json-serialized objects representing the last inserted items.
        /// 
        [HttpGet("GetLatestOld")]
        public IActionResult GetLatestOld()
        {
            return GetLatestOld(DefaultNumberOfItems);
        }

        /// GET: api/items/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// Returns An array of {n} Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatestOld/{n}")]
        public IActionResult GetLatestOld(int n)
        {
            if (n > MaxNumberOfItems) n = MaxNumberOfItems;
            var items = GetSampleItems().OrderByDescending(i => i.CreateDate).Take(n);
            return new JsonResult(items, DefaultJsonSettings);
        }
        #endregion


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
        #endregion


    }
}
