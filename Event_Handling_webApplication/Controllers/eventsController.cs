using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Event_Handling_webApplication.Models;

namespace Event_Handling_webApplication.Controllers
{
    public class eventsController : Controller
    {
        private EventDBContext db = new EventDBContext();
        
        // GET: events
        public async Task<ActionResult> Index()
        {
            return View(await db.tbevents.ToListAsync());
        }

        // GET: events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbevent tbevent = await db.tbevents.FindAsync(id);
            if (tbevent == null)
            {
                return HttpNotFound();
            }
            return View(tbevent);
        }

        // GET: events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "event_id,event_type,title,description,st_date,e_date,org_name,org_contact,max_ticket,available_ticket,city,state")] tbevent tbevent)
        {
            if (ModelState.IsValid)
            {
                db.tbevents.Add(tbevent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbevent);
        }

        // GET: events/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbevent tbevent = await db.tbevents.FindAsync(id);
            if (tbevent == null)
            {
                return HttpNotFound();
            }
            return View(tbevent);
        }

        // POST: events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "event_id,event_type,title,description,st_date,e_date,org_name,org_contact,max_ticket,available_ticket,city,state")] tbevent tbevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbevent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbevent);
        }

        // GET: events/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbevent tbevent = await db.tbevents.FindAsync(id);
            if (tbevent == null)
            {
                return HttpNotFound();
            }
            return View(tbevent);
        }

        // POST: events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbevent tbevent = await db.tbevents.FindAsync(id);
            db.tbevents.Remove(tbevent);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Register(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbevent tbevent = await db.tbevents.FindAsync(id);
            if (tbevent == null)
            {
                return HttpNotFound();
            }
            return View(tbevent);
        }

        public async Task<ActionResult> Summary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbevent tbevent = await db.tbevents.FindAsync(id);
            if (tbevent == null)
            {
                return HttpNotFound();
            }
            return View(tbevent);
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
