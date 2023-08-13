using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentPorfolio_MedVision.Models;

namespace AssignmentPorfolio_MedVision.Controllers
{
    public class CTsController : Controller
    {
        private Model1 db = new Model1();

        // GET: CTs
        public ActionResult Index()
        {
            return View(db.CTs.ToList());
        }

        public ActionResult Search(string TO)
        {
            return View(db.CTs.Where(x => x.CTNo == TO).ToList());
        }

        // GET: CT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT ct = db.CTs.Find(id);
            if (ct == null)
            {
                return HttpNotFound();
            }
            return View(ct);
        }

        // GET: CTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CTId,AvailableMachines,StartDate,StartTime,EndDate,EndTime,Brain,Chest,Waist,Leg,DoctorName,PatientName,FairPrice,CTNo")] CT ct)
        {
            if (ModelState.IsValid)
            {
                db.CTs.Add(ct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ct);
        }

        // GET: CTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT ct = db.CTs.Find(id);
            if (ct == null)
            {
                return HttpNotFound();
            }
            return View(ct);
        }

        // POST: CTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CTId,AvailableMachines,StartDate,StartTime,EndDate,EndTime,Brain,Chest,Waist,Leg,DoctorName,PatientName,FairPrice,CTNo")] CT ct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ct);
        }

        // GET: CTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT ct = db.CTs.Find(id);
            if (ct == null)
            {
                return HttpNotFound();
            }
            return View(ct);
        }

        // POST: CTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT ct = db.CTs.Find(id);
            db.CTs.Remove(ct);
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
