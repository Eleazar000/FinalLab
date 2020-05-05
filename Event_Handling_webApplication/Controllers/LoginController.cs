using Event_Handling_webApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_Handling_webApplication.Controllers
{
    public class LoginController : Controller
    {
        EventDBContext db = new EventDBContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Submit(FormCollection fc)
        //{
        //    string email = fc["email"];
        //    string psw = fc["psw"];
        //    var item = from m in db.logins
        //               select m;
        //    if (email == null || psw == null)
        //    {
        //        TempData["em"] = "Check your credentials!";
        //        return RedirectToAction("UserDashBoard");
        //    }
        //    else
        //    {
        //        item = item.Where(s => s.Email.Equals(email) && s.Password.Equals(psw));
        //        if(item!=null)
        //        {
                    
        //            ViewBag.Message = "successfully login.";
        //        }
        //    }
        //    return RedirectToAction("UserDashBoard");
        //}





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(FormCollection fc)
        {
            string email = fc["email"];
            string psw = fc["psw"];
            if (ModelState.IsValid)
            {
                using (EventDBContext db = new EventDBContext())
                {
                    var obj = db.logins.Where(model => model.Email.Equals(email) && model.Password.Equals(psw)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["login_ID"] = obj.login_ID.ToString();
                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return Content("check your credentials");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["login_ID"] != null)
            {
                TempData["em"] = "login successfully.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["em"] = "Invalid email/password!";
                return Content("Invalid email/password!");
            }
        }



    }
}