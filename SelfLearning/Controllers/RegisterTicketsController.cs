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
    public class RegisterTicketsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: RegisterTickets
        public ActionResult Index()
        {
            var registerTickets = db.RegisterTickets.Include(r => r.Ticket);
            return View(registerTickets.ToList());
        }

        // GET: RegisterTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTicket registerTicket = db.RegisterTickets.Find(id);
            if (registerTicket == null)
            {
                return HttpNotFound();
            }
            return View(registerTicket);
        }

        // GET: RegisterTickets/Create
        public ActionResult Create()
        {
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "TaskDetail");
            return View();
        }

        // POST: RegisterTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TicketId,CreatedDate,ModifiedDate")] RegisterTicket registerTicket)
        {
            if (ModelState.IsValid)
            {
                db.RegisterTickets.Add(registerTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "TaskDetail", registerTicket.TicketId);
            return View(registerTicket);
        }

        // GET: RegisterTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTicket registerTicket = db.RegisterTickets.Find(id);
            if (registerTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "TaskDetail", registerTicket.TicketId);
            return View(registerTicket);
        }

        // POST: RegisterTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TicketId,CreatedDate,ModifiedDate")] RegisterTicket registerTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "TaskDetail", registerTicket.TicketId);
            return View(registerTicket);
        }

        // GET: RegisterTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTicket registerTicket = db.RegisterTickets.Find(id);
            if (registerTicket == null)
            {
                return HttpNotFound();
            }
            return View(registerTicket);
        }

        // POST: RegisterTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterTicket registerTicket = db.RegisterTickets.Find(id);
            db.RegisterTickets.Remove(registerTicket);
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
