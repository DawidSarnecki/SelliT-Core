using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelliT.ViewModels;
using Newtonsoft.Json;
using SelliT.Data;
using SelliT.Data.Users;
using Nelibur.ObjectMapper;

namespace SelliT.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        #region Private Fields
        private SellitContext DbContext;
        #endregion Private Fields

        #region Constructor
        public UsersController(SellitContext context)
        {
            // Dependency Injetion
            DbContext = context;
        }
        #endregion Constructor


        #region RESTful Conventions
        #region HttpGet
        /// GET api/constructors/
        /// Returns: An array of all Json-serialized objects representing the last inserted/modified items.
        [HttpGet()]
        public IActionResult Get()
        {
            var users = DbContext.User
                .OrderByDescending(i => i.ModifyDate)
                .ToArray();
            return new JsonResult(ToViewModelList(users), DefaultJsonSettings);
        }

        /// GET: api/constructors/{id}
        /// Return: A Json-serialized object representing a single item.
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var item = DbContext.User.Where(c => c.ID == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound(new { Error = String.Format("User ID {0} not found", id) });
            }
            else
                return new JsonResult(TinyMapper.Map<UserViewModel>(item), DefaultJsonSettings);
        }
        #endregion HttpGet

        #region HttpPost
        /// POST: api/constructors
        /// Return: Creates a new Item and return it.
        [HttpPost()]
        public IActionResult Add([FromBody]UserViewModel cvm)
        {
            if (cvm != null)
            {
                // create a new User with the client-sent json data
                var newItem = TinyMapper.Map<AppUser>(cvm);

                // override any property that could be set from server-side only
                newItem.ID = Guid.NewGuid().ToString();
                newItem.CreateDate = DateTime.Now;

                //add the new user
                DbContext.User.Add(newItem);

                //save the changes into the db
                DbContext.SaveChanges();

                //return created User to the clinet
                return new JsonResult(TinyMapper.Map<UserViewModel>(newItem), DefaultJsonSettings);
            }
            // return a generic HTTP Status 500 (Not Found) if the client request is invalid.
            return new StatusCodeResult(500);
        }
        #endregion HttpPost

        #region HttpPut
        /// PUT: api/constructors/{id}
        /// Return: Updates an existing User and return it.
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]UserViewModel cvm)
        {
            if (cvm != null)
            {
                // find user with the given ID
                var item = DbContext.User.Where(i => i.ID == id).FirstOrDefault();

                if (item != null)
                {
                    // handle the update
                    item.Name = cvm.Name;
                    item.Nip = cvm.Nip;
                    item.Street = cvm.Street;
                    item.Number = cvm.Number;
                    item.ApartmentNumber = cvm.ApartmentNumber;
                    item.ZipCode = cvm.ZipCode;
                    item.City = cvm.City;
                    item.PersonToInvoice = cvm.PersonToInvoice;

                    // override all properties that could be set from server-side only
                    item.ModifyDate = DateTime.Now;

                    //save the changes into the db
                    DbContext.SaveChanges();

                    //return updated User to the client
                    return new JsonResult(TinyMapper.Map<UserViewModel>(item), DefaultJsonSettings);
                }

            }
            //return a HTTP Status 404 (Not Found) if user has not been found
            return NotFound(new { Error = String.Format("User ID {0} not found", id) });
        }
        #endregion HttpPut


        #region HttpDelete
        /// DELETE: api/constructors/{id}
        /// Return: Removes an existing User, returning a HTTP status 200 (ok) when done.
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = DbContext.User.Where(c => c.ID == id).FirstOrDefault();

            if (item != null)
            {
                // remove the user
                DbContext.User.Remove(item);

                //save the changes into the db
                DbContext.SaveChanges();

                // return an HTTP Status 200 (OK).
                return new OkResult();
            }

            //return a HTTP Status 404 (Not Found) if user has not been found
            return NotFound(new { Error = String.Format("User ID {0} not found", id) });
        }

        #endregion HttpDelete
        #endregion RESTful Conventions


        #region Private Members
        /// Maps a collection of Item entities into a list of ItemViewModel objects.
        /// param name="items": An IEnumerable collection of item entities
        /// Returns a mapped list of UserViewModel objects
        private List<UserViewModel> ToViewModelList(IEnumerable<AppUser> items)
        {
            var lst = new List<UserViewModel>();
            foreach (var item in items)
                lst.Add(TinyMapper.Map<UserViewModel>(item));
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

