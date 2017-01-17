using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelliT.ViewModels;
using Newtonsoft.Json;
using SelliT.Data;
using SelliT.Data.Products;
using Nelibur.ObjectMapper;

namespace SelliT.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        #region Private Fields
        private SellitContext DbContext;
        #endregion Private Fields

        #region Constructor
        public ProductsController(SellitContext context)
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
            var product = DbContext.Product.Where(c => c.ID == id).FirstOrDefault();
            return new JsonResult(TinyMapper.Map<ProductViewModel>(product), DefaultJsonSettings);
        }
        #endregion RESTful Conventions

        #region HttpPost
        /// POST: api/constructors
        /// Return: Creates a new Item and return it.
        [HttpPost()]
        public IActionResult Add([FromBody]ProductViewModel cvm)
        {
            if (cvm != null)
            {
                // create a new Product with the client-sent json data
                var newItem = TinyMapper.Map<Product>(cvm);

                // override any property that could be set from server-side only
                newItem.ID = Guid.NewGuid().ToString();
                newItem.CreateDate = DateTime.Now;
                newItem.ModifyDate = DateTime.Now;

                //add the new item
                DbContext.Product.Add(newItem);

                //save the changes into the db
                DbContext.SaveChanges();

                //return created Product to the clinet
                return new JsonResult(TinyMapper.Map<ProductViewModel>(newItem), DefaultJsonSettings);
            }
            // return a generic HTTP Status 500 (Not Found) if the client request is invalid.
            return new StatusCodeResult(500);
        }
        #endregion HttpPost

        #region HttpPut
        /// PUT: api/constructors/{id}
        /// Return: Updates an existing Product and return it.
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]ProductViewModel cvm)
        {
            if (cvm != null)
            {
                // find Product with the given ID
                var item = DbContext.Product.Where(i => i.ID == id).FirstOrDefault();

                if (item != null)
                {
                    // handle the update
                    item.Name = cvm.Name;
                    item.Unit = cvm.Unit;
                    item.Price = cvm.Price;
                    item.TaxRate = cvm.TaxRate;

                    // override all properties that could be set from server-side only
                    item.ModifyDate = DateTime.Now;

                    //save the changes into the db
                    DbContext.SaveChanges();

                    //return updated Product to the client
                    return new JsonResult(TinyMapper.Map<ContractorViewModel>(item), DefaultJsonSettings);
                }

            }
            //return a HTTP Status 404 (Not Found) if item has not been found
            return NotFound(new { Error = String.Format("Product ID {0} not found", id) });
        }
        #endregion HttpPut


        #region HttpDelete
        /// DELETE: api/constructors/{id}
        /// Return: Removes an existing Product, returning a HTTP status 200 (ok) when done.
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = DbContext.Product.Where(c => c.ID == id).FirstOrDefault();

            if (item != null)
            {
                // remove the item
                DbContext.Product.Remove(item);

                //save the changes into the db
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            //return a HTTP Status 404 (Not Found) if item has not been found
            return NotFound(new { Error = String.Format("Product ID {0} not found", id) });
        }

        #endregion HttpDelete


        #region Attribute-based Routing
        /// GET: api/constructors/GetLatest
        /// ROUTING TYPE: attribute-based
        /// Returns An array of a default number of Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            var products = DbContext.Product
               .OrderByDescending(i => i.ModifyDate)
               .ToArray();

            return new JsonResult(ToProductViewModelList(products), DefaultJsonSettings);
        }

        /// GET: api/constructors/GetLatest/{n}
        /// ROUTING TYPE: attribute-based
        /// Returns An array of {n} Json-serialized objects representing the last inserted items.
        [HttpGet("GetLatest/{n}")]
        public IActionResult GetLatest(int n)
        {
            var products = DbContext.Product
                .OrderByDescending(i => i.ModifyDate)
                .Take(n).ToArray();
            return new JsonResult(ToProductViewModelList(products), DefaultJsonSettings);
        }
        #endregion Attribute-based Routing


        #region Private Members
        /// Maps a collection of Item entities into a list of ItemViewModel objects.
        /// param name="items": An IEnumerable collection of item entities
        /// Returns a mapped list of ContractorViewModel objects
        private List<ProductViewModel> ToProductViewModelList(IEnumerable<Product> products)
        {
            var lst = new List<ProductViewModel>();
            foreach (var i in products)
                lst.Add(TinyMapper.Map<ProductViewModel>(i));
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

        #endregion Private Members


    }
 

}
