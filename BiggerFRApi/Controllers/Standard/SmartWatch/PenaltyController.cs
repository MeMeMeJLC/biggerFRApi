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
using BiggerFRApi.Models;

namespace BiggerFRApi.Controllers.Standard.SmartWatch
{
    public class PenaltyController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/Penalty
        public IQueryable<Penalty> GetPenalties()
        {
            return db.Penalties;
        }

        // GET: api/Penalty/5
        [ResponseType(typeof(Penalty))]
        public async Task<IHttpActionResult> GetPenalty(int id)
        {
            Penalty penalty = await db.Penalties.FindAsync(id);
            if (penalty == null)
            {
                return NotFound();
            }

            return Ok(penalty);
        }

        // PUT: api/Penalty/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPenalty(int id, Penalty penalty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != penalty.Id)
            {
                return BadRequest();
            }

            db.Entry(penalty).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PenaltyExists(id))
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

        // POST: api/Penalty
        [ResponseType(typeof(Penalty))]
        public async Task<IHttpActionResult> PostPenalty(Penalty penalty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Penalties.Add(penalty);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = penalty.Id }, penalty);
        }

        // DELETE: api/Penalty/5
        [ResponseType(typeof(Penalty))]
        public async Task<IHttpActionResult> DeletePenalty(int id)
        {
            Penalty penalty = await db.Penalties.FindAsync(id);
            if (penalty == null)
            {
                return NotFound();
            }

            db.Penalties.Remove(penalty);
            await db.SaveChangesAsync();

            return Ok(penalty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PenaltyExists(int id)
        {
            return db.Penalties.Count(e => e.Id == id) > 0;
        }
    }
}