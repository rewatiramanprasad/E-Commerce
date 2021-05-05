using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models.Account;
using First.Models;
using System.Web.Security;


namespace First.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Payment() 
        {
            return View();
        }

        public ActionResult Product()
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                return View(db.Products.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                using (Database1Entities1 db=new Database1Entities1())
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                }
                return RedirectToAction("Product");

            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            //string email = Request.Cookies["user_email"].Value.ToString();
            using (Database1Entities2 db1 = new Database1Entities2())
            { 
            
            
            }
            using (Database1Entities1 db = new Database1Entities1())
            {
                return View(db.Products.Where(x => x.productId == id).FirstOrDefault());
            }
        }




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
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    db.Users.Add(modal);
                    db.SaveChanges();

                }
                return RedirectToAction("Login");

            }
            catch
            {
                return View();
            }
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
                    Response.Cookies.Add(new HttpCookie("user_email", user.Email.ToString()));
                    //FormsAuthentication.SetAuthCookie(user.Name, false);
                    return RedirectToAction("Product");
                }
                ModelState.AddModelError("", "Wrong combination of email and password");
                return View();
            }
                
        }

    }
}