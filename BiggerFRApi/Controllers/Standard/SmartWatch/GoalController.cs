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
    public class GoalController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/Goal
        public IQueryable<Goal> GetGoals()
        {
            return db.Goals;
        }

        // GET: api/Goal/5
        [ResponseType(typeof(Goal))]
        public async Task<IHttpActionResult> GetGoal(int id)
        {
            Goal goal = await db.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            return Ok(goal);
        }

        // PUT: api/Goal/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGoal(int id, Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goal.Id)
            {
                return BadRequest();
            }

            db.Entry(goal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(id))
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

        // POST: api/Goal
        [ResponseType(typeof(Goal))]
        public async Task<IHttpActionResult> PostGoal(Goal goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Goals.Add(goal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = goal.Id }, goal);
        }

        // DELETE: api/Goal/5
        [ResponseType(typeof(Goal))]
        public async Task<IHttpActionResult> DeleteGoal(int id)
        {
            Goal goal = await db.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }

            db.Goals.Remove(goal);
            await db.SaveChangesAsync();

            return Ok(goal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoalExists(int id)
        {
            return db.Goals.Count(e => e.Id == id) > 0;
        }
    }
}