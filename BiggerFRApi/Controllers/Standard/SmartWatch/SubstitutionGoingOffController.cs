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
    public class SubstitutionGoingOffController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/SubstitutionGoingOff
        public IQueryable<SubstitutionGoingOff> GetSubstitutionGoingOffs()
        {
            return db.SubstitutionGoingOffs;
        }

        // GET: api/SubstitutionGoingOff/5
        [ResponseType(typeof(SubstitutionGoingOff))]
        public async Task<IHttpActionResult> GetSubstitutionGoingOff(int id)
        {
            SubstitutionGoingOff substitutionGoingOff = await db.SubstitutionGoingOffs.FindAsync(id);
            if (substitutionGoingOff == null)
            {
                return NotFound();
            }

            return Ok(substitutionGoingOff);
        }

        // PUT: api/SubstitutionGoingOff/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubstitutionGoingOff(int id, SubstitutionGoingOff substitutionGoingOff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != substitutionGoingOff.Id)
            {
                return BadRequest();
            }

            db.Entry(substitutionGoingOff).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstitutionGoingOffExists(id))
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

        // POST: api/SubstitutionGoingOff
        [ResponseType(typeof(SubstitutionGoingOff))]
        public async Task<IHttpActionResult> PostSubstitutionGoingOff(SubstitutionGoingOff substitutionGoingOff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubstitutionGoingOffs.Add(substitutionGoingOff);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = substitutionGoingOff.Id }, substitutionGoingOff);
        }

        // DELETE: api/SubstitutionGoingOff/5
        [ResponseType(typeof(SubstitutionGoingOff))]
        public async Task<IHttpActionResult> DeleteSubstitutionGoingOff(int id)
        {
            SubstitutionGoingOff substitutionGoingOff = await db.SubstitutionGoingOffs.FindAsync(id);
            if (substitutionGoingOff == null)
            {
                return NotFound();
            }

            db.SubstitutionGoingOffs.Remove(substitutionGoingOff);
            await db.SaveChangesAsync();

            return Ok(substitutionGoingOff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubstitutionGoingOffExists(int id)
        {
            return db.SubstitutionGoingOffs.Count(e => e.Id == id) > 0;
        }
    }
}