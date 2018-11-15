using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SelfLearning.Models;

namespace SelfLearning.Controllers
{
    public class DepartmentTracksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DepartmentTracks
        public ActionResult Index()
        {
            return View(db.DepartmentTracks.ToList());
        }

        // GET: DepartmentTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTrack departmentTrack = db.DepartmentTracks.Find(id);
            if (departmentTrack == null)
            {
                return HttpNotFound();
            }
            return View(departmentTrack);
        }

        // GET: DepartmentTracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentName")] DepartmentTrack departmentTrack)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentTracks.Add(departmentTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentTrack);
        }

        // GET: DepartmentTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTrack departmentTrack = db.DepartmentTracks.Find(id);
            if (departmentTrack == null)
            {
                return HttpNotFound();
            }
            return View(departmentTrack);
        }

        // POST: DepartmentTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentName")] DepartmentTrack departmentTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentTrack);
        }

        // GET: DepartmentTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTrack departmentTrack = db.DepartmentTracks.Find(id);
            if (departmentTrack == null)
            {
                return HttpNotFound();
            }
            return View(departmentTrack);
        }

        // POST: DepartmentTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentTrack departmentTrack = db.DepartmentTracks.Find(id);
            db.DepartmentTracks.Remove(departmentTrack);
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
