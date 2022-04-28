using Emlak2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Emlak2020.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        DataContext db = new DataContext();

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Kullanıcı kullanici)
        {
            var kullanıcı = db.Kullanıcıs.FirstOrDefault(x => x.vatEmail == kullanici.vatEmail && x.vatParola == kullanici.vatParola);

        if(kullanıcı!=null)
            {


                FormsAuthentication.SetAuthCookie(kullanıcı.vatEmail, false);
                return RedirectToAction("Index", "Home");


            }
            else
            {

                ViewBag.mesaj = "Geçersiz kullanıcı adı";
                return View();

            }


          
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public PartialViewResult partial1()
        {

            return PartialView();

        }
        [HttpPost]
        public PartialViewResult partial1(Kullanıcı p)
        {
            db.Kullanıcıs.Add(p);
            db.SaveChanges();
            return PartialView("Login");


        }


    }
}