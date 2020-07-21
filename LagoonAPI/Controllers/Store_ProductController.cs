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
    public class Store_ProductController : ApiController
    {
        private LagoonEntities db = new LagoonEntities();

        // GET: api/Store_Product
        public IQueryable<Store_Product> GetStore_Product()
        {
            return db.Store_Product;
        }

        // GET: api/Store_Product/5
        [ResponseType(typeof(Store_Product))]
        public async Task<IHttpActionResult> GetStore_Product(int id)
        {
            Store_Product store_Product = await db.Store_Product.FindAsync(id);
            if (store_Product == null)
            {
                return NotFound();
            }

            return Ok(store_Product);
        }

        // PUT: api/Store_Product/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStore_Product(int id, Store_Product store_Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store_Product.ID_StoreProduct)
            {
                return BadRequest();
            }

            db.Entry(store_Product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Store_ProductExists(id))
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

        // POST: api/Store_Product
        [ResponseType(typeof(Store_Product))]
        public async Task<IHttpActionResult> PostStore_Product(Store_Product store_Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Store_Product.Add(store_Product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = store_Product.ID_StoreProduct }, store_Product);
        }

        // DELETE: api/Store_Product/5
        [ResponseType(typeof(Store_Product))]
        public async Task<IHttpActionResult> DeleteStore_Product(int id)
        {
            Store_Product store_Product = await db.Store_Product.FindAsync(id);
            if (store_Product == null)
            {
                return NotFound();
            }

            db.Store_Product.Remove(store_Product);
            await db.SaveChangesAsync();

            return Ok(store_Product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Store_ProductExists(int id)
        {
            return db.Store_Product.Count(e => e.ID_StoreProduct == id) > 0;
        }
    }
}