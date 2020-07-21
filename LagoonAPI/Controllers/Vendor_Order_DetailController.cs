using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LagoonAPI.Models;

namespace LagoonAPI.Controllers
{
    public class Vendor_Order_DetailController : ApiController
    {
        private LagoonEntities db = new LagoonEntities();

        // GET: api/Vendor_Order_Detail
        public IQueryable<Vendor_Order_Detail> GetVendor_Order_Detail()
        {
            return db.Vendor_Order_Detail;
        }

        // GET: api/Vendor_Order_Detail/5
        [ResponseType(typeof(Vendor_Order_Detail))]
        public async Task<IHttpActionResult> GetVendor_Order_Detail(int id)
        {
            Vendor_Order_Detail vendor_Order_Detail = await db.Vendor_Order_Detail.FindAsync(id);
            if (vendor_Order_Detail == null)
            {
                return NotFound();
            }

            return Ok(vendor_Order_Detail);
        }

        // PUT: api/Vendor_Order_Detail/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVendor_Order_Detail(int id, Vendor_Order_Detail vendor_Order_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor_Order_Detail.ID_Order)
            {
                return BadRequest();
            }

            db.Entry(vendor_Order_Detail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Vendor_Order_DetailExists(id))
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

        // POST: api/Vendor_Order_Detail
        [ResponseType(typeof(Vendor_Order_Detail))]
        public async Task<IHttpActionResult> PostVendor_Order_Detail(Vendor_Order_Detail vendor_Order_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendor_Order_Detail.Add(vendor_Order_Detail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Vendor_Order_DetailExists(vendor_Order_Detail.ID_Order))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vendor_Order_Detail.ID_Order }, vendor_Order_Detail);
        }

        // DELETE: api/Vendor_Order_Detail/5
        [ResponseType(typeof(Vendor_Order_Detail))]
        public async Task<IHttpActionResult> DeleteVendor_Order_Detail(int id)
        {
            Vendor_Order_Detail vendor_Order_Detail = await db.Vendor_Order_Detail.FindAsync(id);
            if (vendor_Order_Detail == null)
            {
                return NotFound();
            }

            db.Vendor_Order_Detail.Remove(vendor_Order_Detail);
            await db.SaveChangesAsync();

            return Ok(vendor_Order_Detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Vendor_Order_DetailExists(int id)
        {
            return db.Vendor_Order_Detail.Count(e => e.ID_Order == id) > 0;
        }
    }
}