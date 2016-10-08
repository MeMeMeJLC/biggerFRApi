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
    public class SubstitutionController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/Substitution
        public IQueryable<Substitution> GetSubstitutions()
        {
            return db.Substitutions;
        }

        // GET: api/Substitution/5
        [ResponseType(typeof(Substitution))]
        public async Task<IHttpActionResult> GetSubstitution(int id)
        {
            Substitution substitution = await db.Substitutions.FindAsync(id);
            if (substitution == null)
            {
                return NotFound();
            }

            return Ok(substitution);
        }

        // PUT: api/Substitution/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubstitution(int id, Substitution substitution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != substitution.Id)
            {
                return BadRequest();
            }

            db.Entry(substitution).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstitutionExists(id))
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

        // POST: api/Substitution
        [ResponseType(typeof(Substitution))]
        public async Task<IHttpActionResult> PostSubstitution(Substitution substitution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Substitutions.Add(substitution);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = substitution.Id }, substitution);
        }

        // DELETE: api/Substitution/5
        [ResponseType(typeof(Substitution))]
        public async Task<IHttpActionResult> DeleteSubstitution(int id)
        {
            Substitution substitution = await db.Substitutions.FindAsync(id);
            if (substitution == null)
            {
                return NotFound();
            }

            db.Substitutions.Remove(substitution);
            await db.SaveChangesAsync();

            return Ok(substitution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubstitutionExists(int id)
        {
            return db.Substitutions.Count(e => e.Id == id) > 0;
        }
    }
}