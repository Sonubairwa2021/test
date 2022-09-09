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
    public class statesController : Controller
    {
        private InterviewProjectDBEntities db = new InterviewProjectDBEntities();

        // GET: states
        public ActionResult Index()
        {
            var states = db.states.Include(s => s.country);
            return View(states.ToList());
        }

        // GET: states/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state state = db.states.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: states/Create
        public ActionResult Create()
        {
            ViewBag.cid = new SelectList(db.countries, "id", "country1");
            return View();
        }

        // POST: states/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cid,state1")] state state)
        {
            if (ModelState.IsValid)
            {
                db.states.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cid = new SelectList(db.countries, "id", "country1", state.cid);
            return View(state);
        }

        // GET: states/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state state = db.states.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.countries, "id", "country1", state.cid);
            return View(state);
        }

        // POST: states/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cid,state1")] state state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.countries, "id", "country1", state.cid);
            return View(state);
        }

        // GET: states/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            state state = db.states.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: states/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            state state = db.states.Find(id);
            db.states.Remove(state);
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
