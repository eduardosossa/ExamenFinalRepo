using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebNumeroLiteral.Models;

namespace WebNumeroLiteral.Controllers
{
    public class LIteralsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/LIterals
        public IQueryable<LIteral> GetLIterals()
        {
            return db.LIterals;
        }

        // GET: api/LIterals/5
        [ResponseType(typeof(LIteral))]
        public IHttpActionResult GetLIteral(int id)
        {
            LIteral lIteral = db.LIterals.Find(id);
            if (lIteral == null)
            {
                return NotFound();
            }

            return Ok(lIteral);
        }

        // PUT: api/LIterals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLIteral(int id, LIteral lIteral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lIteral.NumeroId)
            {
                return BadRequest();
            }

            db.Entry(lIteral).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LIteralExists(id))
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

        // POST: api/LIterals
        [ResponseType(typeof(LIteral))]
        public IHttpActionResult PostLIteral(LIteral lIteral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LIterals.Add(lIteral);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lIteral.NumeroId }, lIteral);
        }

        // DELETE: api/LIterals/5
        [ResponseType(typeof(LIteral))]
        public IHttpActionResult DeleteLIteral(int id)
        {
            LIteral lIteral = db.LIterals.Find(id);
            if (lIteral == null)
            {
                return NotFound();
            }

            db.LIterals.Remove(lIteral);
            db.SaveChanges();

            return Ok(lIteral);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LIteralExists(int id)
        {
            return db.LIterals.Count(e => e.NumeroId == id) > 0;
        }
    }
}