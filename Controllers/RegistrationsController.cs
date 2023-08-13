using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignmentPorfolio_MedVision.Models;
using AssignmentPorfolio_MedVision.Utils;

namespace AssignmentPorfolio_MedVision.Controllers
{
    public class RegistrationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Registrations
        public ActionResult Index()
        {
            //var registrations = db.Registrations.Include(b => b.CT).Include(b => b.Rating);
            var registrations = db.Registrations.Include(b => b.CT);
            return View(registrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.Patient_id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.CT_id = new SelectList(db.CTs, "CTId", "CTId");
            ViewBag.RegistrationId = new SelectList(db.Ratings, "Registration_id", "Comments");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingDate,NumberOfCTMachine,PaymentAmount,CT_id,Patient_id")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Patient_id = new SelectList(db.AspNetUsers, "Id", "Email", registration.Patient_id);
            ViewBag.CT_id = new SelectList(db.CTs, "CTId", "CTId", registration.CT_id);
            ViewBag.RegistrationId = new SelectList(db.Ratings, "Registration_id", "Comments", registration.BookingId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "Email", registration.Patient_id);
            ViewBag.CT_id = new SelectList(db.CTs, "CTId", "CTId", registration.CT_id);
            ViewBag.BookingId = new SelectList(db.Ratings, "Registration_id", "Comments", registration.BookingId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingDate,NumberOfCTMachine,PaymentAmount,CT_id,Patient_id")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.AspNetUsers, "Id", "Email", registration.Patient_id);
            ViewBag.CT_id = new SelectList(db.CTs, "CTId", "CTId", registration.CT_id);
            ViewBag.BookingId = new SelectList(db.Ratings, "Registration_id", "Comments", registration.BookingId);
            return View(registration);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SendRegistration()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult SendRegistration(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
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
