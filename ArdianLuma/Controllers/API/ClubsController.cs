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
using luma.Models;

namespace luma.Controllers.API
{
    public class ClubsController : ApiController
    {
        private LabModels db = new LabModels();

        // GET: api/Clubs
        public IHttpActionResult GetClubs()
        {
            return Ok(db.Club.ToList());
        }

        // GET: api/Clubs/5
        [ResponseType(typeof(Club))]
        public IHttpActionResult GetClub(int id)
        {
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        // PUT: api/Clubs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClub(int id, Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != club.ClubId)
            {
                return BadRequest();
            }

            db.Entry(club).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(id))
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

        // POST: api/Clubs
        [ResponseType(typeof(Club))]
        public IHttpActionResult PostClub(Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Club.Add(club);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = club.ClubId }, club);
        }

        // DELETE: api/Clubs/5
        [ResponseType(typeof(Club))]
        public IHttpActionResult DeleteClub(int id)
        {
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return NotFound();
            }

            db.Club.Remove(club);
            db.SaveChanges();

            return Ok(club);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClubExists(int id)
        {
            return db.Club.Count(e => e.ClubId == id) > 0;
        }
    }
}