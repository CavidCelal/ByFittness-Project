using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Fitness.ApplicationProject.Models.Business;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize]
    public class KullaniciController : Controller

    {
        // GET: Kullanici
        DbByFitnessEntities db = new DbByFitnessEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SifreReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreReset(string eposta)
        {
            TUser user = new TUser();
             var result =  user.SifreReset(eposta);
            if (result != null)
            {
                ViewBag.uyari="Şifreniz Başarıyla Gönderilmiştir";
            }
            else
            {
                    ViewBag.uyari = "Hata Oluştu Tekrar Deneyiniz";
            }
                //var mail = db.TblKullanici.Where(x => x.KullaniciEmail == eposta).SingleOrDefault();
                //if (mail != null)
                //{
                //    Random rnd = new Random();
                //    int yenisifre = rnd.Next();
                //    TblKullanici sifre = new TblKullanici();
                //    mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre), "MD5");
                //    db.SaveChanges();
                //    WebMail.SmtpServer = "smtp.gmail.com";
                //    WebMail.EnableSsl = true;
                //    WebMail.UserName = "calalcavlan@gmail.com";
                //    WebMail.Password = "Javlon2003Kozirki";
                //    WebMail.SmtpPort = 587;
                //    WebMail.Send(eposta, "Giriş Şifreniz", "Şifreniz" + yenisifre);
                //    ViewBag.uyari="Şifreniz Başarıyla Gönderilmiştir";




                //}
                //
                return View();
        }
    }
}