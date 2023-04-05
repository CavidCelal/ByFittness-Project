using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }
        [Authorize]
        public ActionResult Test()
        {

            return View();
        }
        public ActionResult Contact()
        {
           
                
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string Ad = null, string Tel = null, string Email = null, string Konu = null, string Messaj = null)
        {
            if (Ad != null && Email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName= "calalcavlan@gmail.com";
                WebMail.Password = "jkpryjewblbxlefv";
                WebMail.SmtpPort = 465;
                WebMail.Send("calalcavlan@gmail.com", Konu, Email + "</br>" + Messaj);
                ViewBag.Uyari = "Mesajınız başarı ile gönderilmiştir.";
            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu.Tekrar deneyiniz";
            }
            return View();
        }
        public ActionResult Hakkimizda()
        {
           

            return View();
        }

    }
}