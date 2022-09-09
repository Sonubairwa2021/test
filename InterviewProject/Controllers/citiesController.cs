using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterviewProject;

namespace InterviewProject.Controllers
{
    public class citiesController : Controller
    {
        private InterviewProjectDBEntities db = new InterviewProjectDBEntities();

        // GET: cities
        public ActionResult Index()
        {
            var cities = db.cities.Include(c => c.state);
            return View(cities.ToList());
        }

        // GET: cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: cities/Create
        public ActionResult Create()
        {
            ViewBag.sid = new SelectList(db.states, "id", "state1");
            return View();
        }

        // POST: cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sid,city1")] city city)
        {
            if (ModelState.IsValid)
            {
                db.cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sid = new SelectList(db.states, "id", "state1", city.sid);
            return View(city);
        }

        // GET: cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.sid = new SelectList(db.states, "id", "state1", city.sid);
            return View(city);
        }

        // POST: cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sid,city1")] city city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sid = new SelectList(db.states, "id", "state1", city.sid);
            return View(city);
        }

        // GET: cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            city city = db.cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            city city = db.cities.Find(id);
            db.cities.Remove(city);
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
