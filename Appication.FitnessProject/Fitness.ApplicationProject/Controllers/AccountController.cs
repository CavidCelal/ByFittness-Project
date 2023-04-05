
using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Fitness.ApplicationProject.Models.Business;

namespace Fitness.ApplicationProject.Controllers
{
    public class AccountController : Controller
    {
        DbByFitnessEntities db = new DbByFitnessEntities();
        AccountUser User = new AccountUser();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult Login(TblKullanici kullanici)
        {
            //var Bilgiler = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == p.KullaniciEmail && x.Sifre == p.Sifre);
           
            string Mesaj;
            bool result = User.DoLogin(kullanici, out Mesaj);
            if (result != true)
            {
               
                ViewBag.hata = Mesaj;
            }
            else 
            {
                if (result)
                {           
                    FormsAuthentication.SetAuthCookie(kullanici.KullaniciEmail, false);
                    Session["KullaniciEmail"] = kullanici.KullaniciEmail.ToString();               
                    return RedirectToAction("Test", "Home");
                }
             

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TblKullanici data, string  Messaj)
        {
            var result= User.DoRegister(data, out Messaj);
            if (result)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.hata ="İşlem Başarısız";
            }
            return View();       
        }
        public ActionResult Guncelle()
        {
            var kullanicilar = (string)Session["KullaniciEmail"];
            var degerler = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullanicilar);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Guncelle(TblKullanici data)
        {
            var kullanicilar = (string)Session["KullaniciEmail"];
            var user = db.TblKullanici.Where(x => x.KullaniciEmail == kullanicilar).FirstOrDefault();
            user.Adi = data.Adi;
            user.Soyad = data.Soyad;
            user.KullaniciEmail = data.KullaniciEmail;
            user.KullaniciAdi = data.KullaniciAdi;           
            user.Sifre = data.Sifre;
            user.SifreTekrar = data.SifreTekrar;
          
            db.SaveChanges();
            return RedirectToAction("Test", "Home");
        }

    }
}