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
    public class GamePlayerController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/GamePlayer
        public IQueryable<GamePlayer> GetGamePlayers()
        {
            return db.GamePlayers;
        }

        // GET: api/GamePlayer/5
        [ResponseType(typeof(GamePlayer))]
        public async Task<IHttpActionResult> GetGamePlayer(int id)
        {
            GamePlayer gamePlayer = await db.GamePlayers.FindAsync(id);
            if (gamePlayer == null)
            {
                return NotFound();
            }

            return Ok(gamePlayer);
        }

        // PUT: api/GamePlayer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGamePlayer(int id, GamePlayer gamePlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gamePlayer.Id)
            {
                return BadRequest();
            }

            db.Entry(gamePlayer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamePlayerExists(id))
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

        // POST: api/GamePlayer
        [ResponseType(typeof(GamePlayer))]
        public async Task<IHttpActionResult> PostGamePlayer(GamePlayer gamePlayer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GamePlayers.Add(gamePlayer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gamePlayer.Id }, gamePlayer);
        }

        // DELETE: api/GamePlayer/5
        [ResponseType(typeof(GamePlayer))]
        public async Task<IHttpActionResult> DeleteGamePlayer(int id)
        {
            GamePlayer gamePlayer = await db.GamePlayers.FindAsync(id);
            if (gamePlayer == null)
            {
                return NotFound();
            }

            db.GamePlayers.Remove(gamePlayer);
            await db.SaveChangesAsync();

            return Ok(gamePlayer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GamePlayerExists(int id)
        {
            return db.GamePlayers.Count(e => e.Id == id) > 0;
        }
    }
}