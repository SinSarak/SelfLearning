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
    public class DepartmentTicketsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DepartmentTickets
        public ActionResult Index()
        {
            var departmentTickets = db.DepartmentTickets.Include(d => d.RegisterTicket);
            return View(departmentTickets.ToList());
        }

        // GET: DepartmentTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTicket departmentTicket = db.DepartmentTickets.Find(id);
            if (departmentTicket == null)
            {
                return HttpNotFound();
            }
            return View(departmentTicket);
        }

        // GET: DepartmentTickets/Create
        public ActionResult Create()
        {
            ViewBag.RegisterTicketId = new SelectList(db.RegisterTickets, "Id", "Id");
            return View();
        }

        // POST: DepartmentTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeparmentTrickId,RegisterTicketId,Approved")] DepartmentTicket departmentTicket)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentTickets.Add(departmentTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegisterTicketId = new SelectList(db.RegisterTickets, "Id", "Id", departmentTicket.RegisterTicketId);
            return View(departmentTicket);
        }

        // GET: DepartmentTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTicket departmentTicket = db.DepartmentTickets.Find(id);
            if (departmentTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegisterTicketId = new SelectList(db.RegisterTickets, "Id", "Id", departmentTicket.RegisterTicketId);
            return View(departmentTicket);
        }

        // POST: DepartmentTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeparmentTrickId,RegisterTicketId,Approved")] DepartmentTicket departmentTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegisterTicketId = new SelectList(db.RegisterTickets, "Id", "Id", departmentTicket.RegisterTicketId);
            return View(departmentTicket);
        }

        // GET: DepartmentTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentTicket departmentTicket = db.DepartmentTickets.Find(id);
            if (departmentTicket == null)
            {
                return HttpNotFound();
            }
            return View(departmentTicket);
        }

        // POST: DepartmentTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartmentTicket departmentTicket = db.DepartmentTickets.Find(id);
            db.DepartmentTickets.Remove(departmentTicket);
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
