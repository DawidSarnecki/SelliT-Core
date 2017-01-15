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
        #region HttpGet
        /// GET api/constructors/
        /// Returns: Nothing: this method will raise a HttpNotFound HTTP exception
        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        /// GET: api/constructors/{id}
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var contractor = DbContext.Contractor.Where(c => c.ID == id).FirstOrDefault();
            if (contractor == null)
            {
                return NotFound(new { Error = String.Format("Contractor ID {0} not found", id )});
            }
            else
                return new JsonResult(TinyMapper.Map<ContractorViewModel>(contractor), DefaultJsonSettings);
        }
        #endregion HttpGet

        #region HttpPost
        /// POST: api/constructors
        /// Return: Creates a new Item and return it.
        [HttpPost()]
        public IActionResult Add([FromBody]ContractorViewModel cvm)
        {
            if (cvm != null)
            {
                // create a new Contractor with the client-sent json data
                var newContractor = TinyMapper.Map<Contractor>(cvm);

                // override any property that could be set from server-side only
                newContractor.ID = Guid.NewGuid().ToString();
                newContractor.CreateDate = DateTime.Now;

                //add the new contractor
                DbContext.Contractor.Add(newContractor);

                //save the changes into the db
                DbContext.SaveChanges();

                //return created Contractor to the clinet
                return new JsonResult(TinyMapper.Map<ContractorViewModel>(newContractor), DefaultJsonSettings);
            }
            // return a generic HTTP Status 500 (Not Found) if the client request is invalid.
            return new StatusCodeResult(500);
        }
        #endregion HttpPost

        #region HttpPut
        /// PUT: api/constructors/{id}
        /// Return: Updates an existing Contractor and return it.
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]ContractorViewModel cvm)
        {
            if (cvm != null)
            {
                // find contractor with the given ID
                var contractor = DbContext.Contractor.Where(i => i.ID == id).FirstOrDefault();

                if (contractor != null)
                {
                    // handle the update
                    contractor.Name = cvm.Name;
                    contractor.Nip = cvm.Nip;
                    contractor.Street = cvm.Street;
                    contractor.Number = cvm.Number;
                    contractor.ApartmentNumber = cvm.ApartmentNumber;
                    contractor.ZipCode = cvm.ZipCode;
                    contractor.City = cvm.City;
                    contractor.PersonToInvoice = cvm.PersonToInvoice;
                        
                    // override all properties that could be set from server-side only
                    contractor.ModifyDate = DateTime.Now;

                    //save the changes into the db
                    DbContext.SaveChanges();

                    //return updated Contractor to the client
                    return new JsonResult(TinyMapper.Map<ContractorViewModel>(contractor), DefaultJsonSettings);
                }

            }
                //return a HTTP Status 404 (Not Found) if contractor has not been found
                return NotFound(new { Error = String.Format("Contractor ID {0} not found", id) });
        }
        #endregion HttpPut


        #region HttpDelete
        /// DELETE: api/constructors/{id}
        /// Return: Removes an existing Contractor, returning a HTTP status 200 (ok) when done.
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contractor = DbContext.Contractor.Where(c => c.ID == id).FirstOrDefault();

            if (contractor != null)
            {
                // remove the contractor
                DbContext.Contractor.Remove(contractor);

                //save the changes into the db
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }
            
            //return a HTTP Status 404 (Not Found) if contractor has not been found
            return NotFound(new { Error = String.Format("Contractor ID {0} not found", id) });
        }

        #endregion HttpDelete
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
            var contracors = DbContext.Contractor
                .OrderByDescending(i => i.ModifyDate)
                .Take(n).ToArray();
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
                return 20;
            }
        }

        /// Returns the maximum number using the API methods retrieving item lists.
        private int MaxNumberOfItems
        {
            get
            {
                return 30;
            }
        }
        #endregion Private Members


    }
}
