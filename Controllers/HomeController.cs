using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models.Account;
using System.Web.Security;


namespace First.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User modal)
        {
            using (var context=new Database1Entities())
            {
                context.Users.Add(modal);
                context.SaveChanges();
            
            }
                return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var context=new Database1Entities())
            {
                bool isValid = context.Users.Any(x => x.Email == user.Email && x.Password == user.Password);
                if (isValid)
                {
                    //FormsAuthentication.SetAuthCookie(user.Name, false);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "invalid username and password");
                return View();
            }
                
        }

    }
}