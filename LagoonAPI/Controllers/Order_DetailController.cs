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
    public class Order_DetailController : ApiController
    {
        private LagoonEntities db = new LagoonEntities();

        // GET: api/Order_Detail
        public IQueryable<Order_Detail> GetOrder_Detail()
        {
            return db.Order_Detail;
        }

        // GET: api/Order_Detail/5
        [ResponseType(typeof(Order_Detail))]
        public async Task<IHttpActionResult> GetOrder_Detail(int id)
        {
            Order_Detail order_Detail = await db.Order_Detail.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            return Ok(order_Detail);
        }

        // PUT: api/Order_Detail/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder_Detail(int id, Order_Detail order_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_Detail.ID_Order)
            {
                return BadRequest();
            }

            db.Entry(order_Detail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_DetailExists(id))
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

        // POST: api/Order_Detail
        [ResponseType(typeof(Order_Detail))]
        public async Task<IHttpActionResult> PostOrder_Detail(Order_Detail order_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_Detail.Add(order_Detail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Order_DetailExists(order_Detail.ID_Order))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_Detail.ID_Order }, order_Detail);
        }

        // DELETE: api/Order_Detail/5
        [ResponseType(typeof(Order_Detail))]
        public async Task<IHttpActionResult> DeleteOrder_Detail(int id)
        {
            Order_Detail order_Detail = await db.Order_Detail.FindAsync(id);
            if (order_Detail == null)
            {
                return NotFound();
            }

            db.Order_Detail.Remove(order_Detail);
            await db.SaveChangesAsync();

            return Ok(order_Detail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_DetailExists(int id)
        {
            return db.Order_Detail.Count(e => e.ID_Order == id) > 0;
        }
    }
}