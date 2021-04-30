using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models;
using First.Models.Account;

namespace First.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( User user)
        {
            
                return View();
        }
    }
}