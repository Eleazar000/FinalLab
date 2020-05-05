using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;
using System;
using Event_Handling_webApplication.Models;
using System.Linq;
using System.Data.SqlClient;

namespace Event_Handling_webApplication.Controllers
{
    public class HomeController : Controller
    {
        private EventDBContext db = new EventDBContext();

        // GET: events
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now.AddDays(2);
            var item = from m in db.tbevents
                       select m;
            item = item.Where(s => s.st_date < dt);
            return View(item);
        }

        public ActionResult FindEvent(string eventType, string City)
        {
            var item = from m in db.tbevents
                       select m;
            if (!String.IsNullOrEmpty(eventType))
            {
                item = item.Where(s => s.event_type.ToString() == eventType || s.title.Contains(eventType));
            }
            if (!String.IsNullOrEmpty(City))
            {
                item = item.Where(s => s.city.Contains(City) || s.state.Contains(City));
            }
            return View(item);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}