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
    public class RefereeController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/Referee
        public IQueryable<Referee> GetReferees()
        {
            return db.Referees;
        }

        // GET: api/Referee/5
        [ResponseType(typeof(Referee))]
        public async Task<IHttpActionResult> GetReferee(int id)
        {
            Referee referee = await db.Referees.FindAsync(id);
            if (referee == null)
            {
                return NotFound();
            }

            return Ok(referee);
        }

        // PUT: api/Referee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReferee(int id, Referee referee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referee.Id)
            {
                return BadRequest();
            }

            db.Entry(referee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefereeExists(id))
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

        // POST: api/Referee
        [ResponseType(typeof(Referee))]
        public async Task<IHttpActionResult> PostReferee(Referee referee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Referees.Add(referee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = referee.Id }, referee);
        }

        // DELETE: api/Referee/5
        [ResponseType(typeof(Referee))]
        public async Task<IHttpActionResult> DeleteReferee(int id)
        {
            Referee referee = await db.Referees.FindAsync(id);
            if (referee == null)
            {
                return NotFound();
            }

            db.Referees.Remove(referee);
            await db.SaveChangesAsync();

            return Ok(referee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefereeExists(int id)
        {
            return db.Referees.Count(e => e.Id == id) > 0;
        }
    }
}