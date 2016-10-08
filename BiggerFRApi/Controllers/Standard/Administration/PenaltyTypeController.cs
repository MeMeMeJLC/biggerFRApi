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

namespace BiggerFRApi.Controllers.Standard.Administration
{
    public class PenaltyTypeController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/PenaltyType
        public IQueryable<PenaltyType> GetPenaltyTypes()
        {
            return db.PenaltyTypes;
        }

        // GET: api/PenaltyType/5
        [ResponseType(typeof(PenaltyType))]
        public async Task<IHttpActionResult> GetPenaltyType(int id)
        {
            PenaltyType penaltyType = await db.PenaltyTypes.FindAsync(id);
            if (penaltyType == null)
            {
                return NotFound();
            }

            return Ok(penaltyType);
        }

        // PUT: api/PenaltyType/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPenaltyType(int id, PenaltyType penaltyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != penaltyType.Id)
            {
                return BadRequest();
            }

            db.Entry(penaltyType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PenaltyTypeExists(id))
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

        // POST: api/PenaltyType
        [ResponseType(typeof(PenaltyType))]
        public async Task<IHttpActionResult> PostPenaltyType(PenaltyType penaltyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PenaltyTypes.Add(penaltyType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = penaltyType.Id }, penaltyType);
        }

        // DELETE: api/PenaltyType/5
        [ResponseType(typeof(PenaltyType))]
        public async Task<IHttpActionResult> DeletePenaltyType(int id)
        {
            PenaltyType penaltyType = await db.PenaltyTypes.FindAsync(id);
            if (penaltyType == null)
            {
                return NotFound();
            }

            db.PenaltyTypes.Remove(penaltyType);
            await db.SaveChangesAsync();

            return Ok(penaltyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PenaltyTypeExists(int id)
        {
            return db.PenaltyTypes.Count(e => e.Id == id) > 0;
        }
    }
}