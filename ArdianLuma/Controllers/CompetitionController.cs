using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using luma.Models;
using luma.ViewModels;

namespace luma.Controllers
{
    public class CompetitionController : Controller
    {
        private LabModels db = new LabModels();


        public ActionResult Index()
        {
            return View(db.Competition.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetitionId,Name,Location,StartDate,EndDate,Description")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competition.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competition);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var competitionViewModel = new CompetitionViewModel
            {
                Competition = db.Competition.Include(i => i.Members).First(i => i.CompetitionId == id)
            };

            if (competitionViewModel.Competition == null)
            {
                return HttpNotFound();
            }

            var allMemberList = db.Member.ToList();
            competitionViewModel.AllMembers = allMemberList.Select(m => new SelectListItem
            {
                Text = m.FirstName,
                Value = m.MemberId.ToString()
            });

            return View(competitionViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompetitionViewModel competitionView)
        {
            if (competitionView == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var competitionToUpdate = db.Competition
                    .Include(c => c.Members).First(c => c.CompetitionId == competitionView.Competition.CompetitionId);

                if (TryUpdateModel(competitionToUpdate, "Competition", new string[] { "Name", "Location", "StartDate", "EndDate", "Description", "CompetitionId" }))
                {
                    var newMembers = db.Member.Where(
                        m => competitionView.SelectedMembers.Contains(m.MemberId)).ToList();
                    var updatedMembers = new HashSet<int>(competitionView.SelectedMembers);

                    foreach (Member member in db.Member)
                    {
                        if (!updatedMembers.Contains(member.MemberId))
                        {
                            competitionToUpdate.Members.Remove(member);
                        }
                        else
                        {
                            competitionToUpdate.Members.Add((member));
                        }
                    }
                    db.Entry(competitionToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(competitionView);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competition.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competition.Find(id);
            db.Competition.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
