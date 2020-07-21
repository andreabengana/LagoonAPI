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
    public class Product_FeedbackController : ApiController
    {
        private LagoonEntities db = new LagoonEntities();

        // GET: api/Product_Feedback
        public IQueryable<Product_Feedback> GetProduct_Feedback()
        {
            return db.Product_Feedback;
        }

        // GET: api/Product_Feedback/5
        [ResponseType(typeof(Product_Feedback))]
        public async Task<IHttpActionResult> GetProduct_Feedback(int id)
        {
            Product_Feedback product_Feedback = await db.Product_Feedback.FindAsync(id);
            if (product_Feedback == null)
            {
                return NotFound();
            }

            return Ok(product_Feedback);
        }

        // PUT: api/Product_Feedback/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct_Feedback(int id, Product_Feedback product_Feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_Feedback.ID_ProductFeedback)
            {
                return BadRequest();
            }

            db.Entry(product_Feedback).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_FeedbackExists(id))
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

        // POST: api/Product_Feedback
        [ResponseType(typeof(Product_Feedback))]
        public async Task<IHttpActionResult> PostProduct_Feedback(Product_Feedback product_Feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product_Feedback.Add(product_Feedback);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product_Feedback.ID_ProductFeedback }, product_Feedback);
        }

        // DELETE: api/Product_Feedback/5
        [ResponseType(typeof(Product_Feedback))]
        public async Task<IHttpActionResult> DeleteProduct_Feedback(int id)
        {
            Product_Feedback product_Feedback = await db.Product_Feedback.FindAsync(id);
            if (product_Feedback == null)
            {
                return NotFound();
            }

            db.Product_Feedback.Remove(product_Feedback);
            await db.SaveChangesAsync();

            return Ok(product_Feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product_FeedbackExists(int id)
        {
            return db.Product_Feedback.Count(e => e.ID_ProductFeedback == id) > 0;
        }
    }
}