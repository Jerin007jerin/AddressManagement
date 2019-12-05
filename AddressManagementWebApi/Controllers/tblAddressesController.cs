using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AddressManagementWebApi.Models;

namespace AddressManagementWebApi.Controllers
{
    public class tblAddressesController : ApiController
    {
        private AddressDBEntities db = new AddressDBEntities();

        // GET: api/tblAddresses
        public IQueryable<tblAddress> GettblAddresses()
        {
            return db.tblAddresses;
        }

        // GET: api/tblAddresses/5
        [ResponseType(typeof(tblAddress))]
        public IHttpActionResult GettblAddress(int id)
        {
            tblAddress tblAddress = db.tblAddresses.Find(id);
            if (tblAddress == null)
            {
                return NotFound();
            }

            return Ok(tblAddress);
        }
        //Get 
        public List<tblAddress> GetAssetDefs(string name)
        {
            List<tblAddress> alist = db.tblAddresses.Where(x => x.Familyname.StartsWith(name)).ToList();
            return alist;
        }

        // PUT: api/tblAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAddress(int id, tblAddress tblAddress)
        {
          

            if (id != tblAddress.AddressId)
            {
                return BadRequest();
            }

            db.Entry(tblAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tblAddresses
        [ResponseType(typeof(tblAddress))]
        public IHttpActionResult PosttblAddress(tblAddress tblAddress)
        {
           

            db.tblAddresses.Add(tblAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblAddress.AddressId }, tblAddress);
        }

        // DELETE: api/tblAddresses/5
        [ResponseType(typeof(tblAddress))]
        public IHttpActionResult DeletetblAddress(int id)
        {
            tblAddress tblAddress = db.tblAddresses.Find(id);
            if (tblAddress == null)
            {
                return NotFound();
            }

            db.tblAddresses.Remove(tblAddress);
            db.SaveChanges();

            return Ok(tblAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAddressExists(int id)
        {
            return db.tblAddresses.Count(e => e.AddressId == id) > 0;
        }
    }
}