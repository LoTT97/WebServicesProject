using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ClubCompetition.Models;

namespace ClubCompetition.Controllers.API
{
    [EnableCors("http://localhost:4200", headers: "*", methods: "*")]
    public class CompetitionsController : ApiController
    {
        private LabModels db = new LabModels();

        // GET: api/Competitions
        public IHttpActionResult GetCompetitions()
        {
            return Ok(db.Competition.ToList());
        }

        // GET: api/Competitions/5
        [ResponseType(typeof(Competition))]
        public IHttpActionResult GetCompetition(int id)
        {
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return NotFound();
            }

            return Ok(competition);
        }

        // PUT: api/Competitions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompetition(int id, Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competition.CompetitionId)
            {
                return BadRequest();
            }

            db.Entry(competition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
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

        // POST: api/Competitions
        [ResponseType(typeof(Competition))]
        public IHttpActionResult PostCompetition(Competition competition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Competition.Add(competition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = competition.CompetitionId }, competition);
        }

        // DELETE: api/Competitions/5
        [ResponseType(typeof(Competition))]
        public IHttpActionResult DeleteCompetition(int id)
        {
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return NotFound();
            }

            db.Competition.Remove(competition);
            db.SaveChanges();

            return Ok(competition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompetitionExists(int id)
        {
            return db.Competition.Count(e => e.CompetitionId == id) > 0;
        }
    }
}