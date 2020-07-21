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
    public class Store_FeedbackController : ApiController
    {
        private LagoonEntities db = new LagoonEntities();

        // GET: api/Store_Feedback
        public IQueryable<Store_Feedback> GetStore_Feedback()
        {
            return db.Store_Feedback;
        }

        // GET: api/Store_Feedback/5
        [ResponseType(typeof(Store_Feedback))]
        public async Task<IHttpActionResult> GetStore_Feedback(int id)
        {
            Store_Feedback store_Feedback = await db.Store_Feedback.FindAsync(id);
            if (store_Feedback == null)
            {
                return NotFound();
            }

            return Ok(store_Feedback);
        }

        // PUT: api/Store_Feedback/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStore_Feedback(int id, Store_Feedback store_Feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store_Feedback.ID_StoreFeedback)
            {
                return BadRequest();
            }

            db.Entry(store_Feedback).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Store_FeedbackExists(id))
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

        // POST: api/Store_Feedback
        [ResponseType(typeof(Store_Feedback))]
        public async Task<IHttpActionResult> PostStore_Feedback(Store_Feedback store_Feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Store_Feedback.Add(store_Feedback);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = store_Feedback.ID_StoreFeedback }, store_Feedback);
        }

        // DELETE: api/Store_Feedback/5
        [ResponseType(typeof(Store_Feedback))]
        public async Task<IHttpActionResult> DeleteStore_Feedback(int id)
        {
            Store_Feedback store_Feedback = await db.Store_Feedback.FindAsync(id);
            if (store_Feedback == null)
            {
                return NotFound();
            }

            db.Store_Feedback.Remove(store_Feedback);
            await db.SaveChangesAsync();

            return Ok(store_Feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Store_FeedbackExists(int id)
        {
            return db.Store_Feedback.Count(e => e.ID_StoreFeedback == id) > 0;
        }
    }
}