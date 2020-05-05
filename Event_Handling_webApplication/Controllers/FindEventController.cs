using System.Web.Mvc;
using Event_Handling_webApplication.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System;

namespace Event_Handling_webApplication.Controllers
{
    public class FindEventController : Controller
    {
        private EventDBContext db = new EventDBContext();
        //private EventDBContext db = new EventDBContext();
        // GET: FindEvent
        public ActionResult FindEvent(string eventType, string City)
        {
            var item = from m in db.tbevents
                       select m;
            if (!String.IsNullOrEmpty(eventType))
            {
                item = item.Where(s => s.event_type.ToString() == eventType || s.title.Contains(eventType));
            }
            if(!String.IsNullOrEmpty(City))
            {
                item = item.Where(s => s.city.Contains(City) || s.state.Contains(City));
            }
            return View(item);
        }

        //public ActionResult FindEvent(tbevent item)
        //{
        //    return View(item);
        //}

        public ActionResult NavigateDetails()
        {
            return RedirectToAction("Details", "events");
        }

        public async Task<ActionResult> Search(int? id)
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
    }

}