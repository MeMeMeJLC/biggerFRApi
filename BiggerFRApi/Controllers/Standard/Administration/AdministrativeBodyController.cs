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
    public class AdministrativeBodyController : ApiController
    {
        private BiggerFRApiContext db = new BiggerFRApiContext();

        // GET: api/AdministrativeBody
        public IQueryable<AdministrativeBody> GetAdministrativeBodies()
        {
            return db.AdministrativeBodies;
        }

        // GET: api/AdministrativeBody/5
        [ResponseType(typeof(AdministrativeBody))]
        public async Task<IHttpActionResult> GetAdministrativeBody(int id)
        {
            AdministrativeBody administrativeBody = await db.AdministrativeBodies.FindAsync(id);
            if (administrativeBody == null)
            {
                return NotFound();
            }

            return Ok(administrativeBody);
        }

        // PUT: api/AdministrativeBody/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministrativeBody(int id, AdministrativeBody administrativeBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrativeBody.Id)
            {
                return BadRequest();
            }

            db.Entry(administrativeBody).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministrativeBodyExists(id))
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

        // POST: api/AdministrativeBody
        [ResponseType(typeof(AdministrativeBody))]
        public async Task<IHttpActionResult> PostAdministrativeBody(AdministrativeBody administrativeBody)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdministrativeBodies.Add(administrativeBody);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administrativeBody.Id }, administrativeBody);
        }

        // DELETE: api/AdministrativeBody/5
        [ResponseType(typeof(AdministrativeBody))]
        public async Task<IHttpActionResult> DeleteAdministrativeBody(int id)
        {
            AdministrativeBody administrativeBody = await db.AdministrativeBodies.FindAsync(id);
            if (administrativeBody == null)
            {
                return NotFound();
            }

            db.AdministrativeBodies.Remove(administrativeBody);
            await db.SaveChangesAsync();

            return Ok(administrativeBody);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministrativeBodyExists(int id)
        {
            return db.AdministrativeBodies.Count(e => e.Id == id) > 0;
        }
    }
}