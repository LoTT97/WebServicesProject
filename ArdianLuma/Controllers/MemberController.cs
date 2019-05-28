using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using luma.Models;

namespace luma.Controllers
{
    public class MemberController : Controller
    {
        private LabModels db;

        public MemberController()
        {
            db = new LabModels();
        }


        public ActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search)) {
                int memberID=0;
                Int32.TryParse(search, out memberID);

                return View(db.Member.Where(x => x.FirstName.Contains(search) || x.MemberId == memberID).ToList());
            }else {
                return View(db.Member.ToList());
            }
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }



        public ActionResult Create()
        {
            ViewBag.ClubNames = new SelectList(db.Club, "ClubId", "ClubName");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,DateOfBirth,Height,Weight,Email,Phone,ClubId")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Member.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            ViewBag.ClubNames = new SelectList(db.Club, "ClubId", "ClubName", member.ClubId);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,DateOfBirth,Height,Weight,Email,Phone,ClubId")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            db.Member.Remove(member);
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
