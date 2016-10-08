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
    public class LeagueSeasonController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/LeagueSeason
        public IQueryable<LeagueSeason> GetLeagueSeasons()
        {
            return db.LeagueSeasons;
        }

        // GET: api/LeagueSeason/5
        [ResponseType(typeof(LeagueSeason))]
        public async Task<IHttpActionResult> GetLeagueSeason(int id)
        {
            LeagueSeason leagueSeason = await db.LeagueSeasons.FindAsync(id);
            if (leagueSeason == null)
            {
                return NotFound();
            }

            return Ok(leagueSeason);
        }

        // PUT: api/LeagueSeason/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeagueSeason(int id, LeagueSeason leagueSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leagueSeason.Id)
            {
                return BadRequest();
            }

            db.Entry(leagueSeason).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueSeasonExists(id))
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

        // POST: api/LeagueSeason
        [ResponseType(typeof(LeagueSeason))]
        public async Task<IHttpActionResult> PostLeagueSeason(LeagueSeason leagueSeason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeagueSeasons.Add(leagueSeason);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leagueSeason.Id }, leagueSeason);
        }

        // DELETE: api/LeagueSeason/5
        [ResponseType(typeof(LeagueSeason))]
        public async Task<IHttpActionResult> DeleteLeagueSeason(int id)
        {
            LeagueSeason leagueSeason = await db.LeagueSeasons.FindAsync(id);
            if (leagueSeason == null)
            {
                return NotFound();
            }

            db.LeagueSeasons.Remove(leagueSeason);
            await db.SaveChangesAsync();

            return Ok(leagueSeason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeagueSeasonExists(int id)
        {
            return db.LeagueSeasons.Count(e => e.Id == id) > 0;
        }
    }
}