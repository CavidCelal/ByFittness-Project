using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Security.Claims;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize]
    public class SatisController : Controller
    {
        // GET: Satis
        DbByFitnessEntities db = new DbByFitnessEntities();
        public ActionResult Index(int sayfa = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
                var model = db.TblSatislar.Where(x => x.KullaniciId == kullanici.KullaniciId).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult SatinAl(int id)
        {
            var model = db.TblSepet.FirstOrDefault(x => x.SepetId == id);
            return View(model);
                
        }
        [HttpPost]
        public ActionResult SatinAl2(int SepetId)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                  
                    var model = db.TblSepet.FirstOrDefault(x => x.SepetId == SepetId);

                    var satis = new TblSatislar
                    {
                        KullaniciId = model.KullaniciId,

                        UrunId = model.UrunId,
                        Adet = model.Adet,
                        Resim = model.Resim,
                        Fiyat = model.Fiyat,
                        Tarih = model.Tarih,
                       
                    };
                    db.TblSepet.Remove(model);
                    db.TblSatislar.Add(satis);
                    db.SaveChanges();
                    
                   
                    return RedirectToAction("Address", "Satis");
                }
            }
            catch (Exception)
            {

                ViewBag.islem = "Satın Alma İşlemi Başarısız";
                //return RedirectToAction("ErrorFound", "Index");

            }
            return View();
        }
        public ActionResult HepsiniSatinAl(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
                var model = db.TblSepet.Where(x => x.KullaniciId == kullanici.KullaniciId).ToList();
                var kid = db.TblSepet.FirstOrDefault(x => x.KullaniciId == kullanici.KullaniciId);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmamaktadır";
                    }
                    else if (kid != null )
                    {
                        Tutar = db.TblSepet.Where(x => x.KullaniciId == kid.KullaniciId).Sum(x => x.TblUrun.Fiyat * x.Adet);
                        ViewBag.Tutar = "Toplam tutar = " + Tutar + "TL";
                    }
                    return View(model);
                    
                }
                return View();
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult HepsiniSatinAl2()
        {
           
                var username = User.Identity.Name;
                var kullanici = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == username);
                var model = db.TblSepet.Where(x => x.KullaniciId == kullanici.KullaniciId).ToList();
                int satir = 0;
                foreach (var item in model)
                {
                    var satis = new TblSatislar
                    {
                        KullaniciId = model[satir].KullaniciId,
                        UrunId = model[satir].UrunId,
                        Adet = model[satir].Adet,
                        Fiyat = model[satir].Fiyat,
                        Resim = model[satir].Resim,
                        Tarih = DateTime.Now
                    };
                    db.TblSatislar.Add(satis);
                    db.SaveChanges();
                    satir++;
                }
                db.TblSepet.RemoveRange(model);
                db.SaveChanges();
          

            return RedirectToAction("Address", "Satis");
        } 
        public ActionResult EgitimSatisIndex(int sayfa = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
                var model = db.TblSatislar.Where(x => x.KullaniciId == kullanici.KullaniciId).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult EgitimSatinAl(int id)
        {
            var model = db.TblEgitim.FirstOrDefault(x => x.EgitimId == id);
            return View(model);

        }
        [HttpPost]
        public ActionResult EgitimSatinAl2(TblEgitim egitim)
        {       
            return RedirectToAction("Address", "Satis");
        }
        public ActionResult Address()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Address(TblAddress data)
        {
            var kullaniciadi = User.Identity.Name;
            var model = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
            var u = db.TblAddress.Find(data.KullaniciId);
            var sepet = db.TblAddress.FirstOrDefault(x => x.KullaniciId == model.KullaniciId && x.AddressId ==data.AddressId);
            if (model != null)
            {

                var s = new TblAddress
                {
                    KullaniciId = model.KullaniciId,
                    Ulke = data.Ulke,
                    Sehir = data.Sehir,
                    Il = data.Il,
                    Address = data.Address,
                    PostaKodu = data.PostaKodu,
                };
                db.TblAddress.Add(s);
                db.SaveChanges();
                ViewBag.EgitimIslem = "Satın Alma İşlemi Başarılı Bir Şekilde Gerçekleşmiştir, Kısa bir süre sonra iletişime geçeceğiz!";
            }
            else
            {
                ViewBag.EgitimIslem = "Satın Alma İşlemi Başarısız! Tekrar Deneyin. ";
            }
            return View("EgitimIslem");
        }                                      

    }
}