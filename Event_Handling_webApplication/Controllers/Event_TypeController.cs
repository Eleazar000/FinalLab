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
    public class Event_TypeController : Controller
    {
        public EventDBContext db = new EventDBContext();

        // GET: Event_Type
        public async Task<ActionResult> Index()
        {
            return View(await db.Event_Types.ToListAsync());
        }

        // GET: Event_Type/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = await db.Event_Types.FindAsync(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // GET: Event_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "event_type_ID,event_type1")] Event_Type event_Type)
        {
            if (ModelState.IsValid)
            {
                db.Event_Types.Add(event_Type);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(event_Type);
        }

        // GET: Event_Type/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = await db.Event_Types.FindAsync(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // POST: Event_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "event_type_ID,event_type1")] Event_Type event_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event_Type).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(event_Type);
        }

        // GET: Event_Type/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = await db.Event_Types.FindAsync(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // POST: Event_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Event_Type event_Type = await db.Event_Types.FindAsync(id);
            db.Event_Types.Remove(event_Type);
            await db.SaveChangesAsync();
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
