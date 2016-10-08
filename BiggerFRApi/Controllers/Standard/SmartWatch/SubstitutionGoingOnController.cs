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
    public class SubstitutionGoingOnController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/SubstitutionGoingOn
        public IQueryable<SubstitutionGoingOn> GetSubstitutionGoingOns()
        {
            return db.SubstitutionGoingOns;
        }

        // GET: api/SubstitutionGoingOn/5
        [ResponseType(typeof(SubstitutionGoingOn))]
        public async Task<IHttpActionResult> GetSubstitutionGoingOn(int id)
        {
            SubstitutionGoingOn substitutionGoingOn = await db.SubstitutionGoingOns.FindAsync(id);
            if (substitutionGoingOn == null)
            {
                return NotFound();
            }

            return Ok(substitutionGoingOn);
        }

        // PUT: api/SubstitutionGoingOn/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubstitutionGoingOn(int id, SubstitutionGoingOn substitutionGoingOn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != substitutionGoingOn.Id)
            {
                return BadRequest();
            }

            db.Entry(substitutionGoingOn).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstitutionGoingOnExists(id))
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

        // POST: api/SubstitutionGoingOn
        [ResponseType(typeof(SubstitutionGoingOn))]
        public async Task<IHttpActionResult> PostSubstitutionGoingOn(SubstitutionGoingOn substitutionGoingOn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubstitutionGoingOns.Add(substitutionGoingOn);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = substitutionGoingOn.Id }, substitutionGoingOn);
        }

        // DELETE: api/SubstitutionGoingOn/5
        [ResponseType(typeof(SubstitutionGoingOn))]
        public async Task<IHttpActionResult> DeleteSubstitutionGoingOn(int id)
        {
            SubstitutionGoingOn substitutionGoingOn = await db.SubstitutionGoingOns.FindAsync(id);
            if (substitutionGoingOn == null)
            {
                return NotFound();
            }

            db.SubstitutionGoingOns.Remove(substitutionGoingOn);
            await db.SaveChangesAsync();

            return Ok(substitutionGoingOn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubstitutionGoingOnExists(int id)
        {
            return db.SubstitutionGoingOns.Count(e => e.Id == id) > 0;
        }
    }
}