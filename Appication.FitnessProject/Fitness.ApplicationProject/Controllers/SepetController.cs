using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        // GET: Sepet
        DbByFitnessEntities db = new DbByFitnessEntities();
        public ActionResult Index(decimal?Tutar)
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
                        ViewBag.Tutar="Sepette ürün bulunmamaktadır";
                    }
                    else if (kid != null)
                    {
                        Tutar=db.TblSepet.Where(x => x.KullaniciId == kid.KullaniciId).Sum(x => x.TblUrun.Fiyat*x.Adet);
                        ViewBag.Tutar="Toplam Tutar ="+ Tutar + "TL";
                    }
                    return View(model);
                }
            }

            return HttpNotFound();
        }
        public ActionResult SepeteEkle(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
                var u = db.TblUrun.Find(id);
                var sepet = db.TblSepet.FirstOrDefault(x => x.KullaniciId == model.KullaniciId && x.UrunId ==id);
                if (model != null)
                {
                    if (sepet != null)
                    {
                        sepet.Adet++;
                        sepet.Fiyat = u.Fiyat*sepet.Adet;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var s = new TblSepet
                    {
                        KullaniciId = model.KullaniciId,
                        UrunId = u.UrunId,
                        Adet=1,
                        Fiyat=u.Fiyat,
                        Tarih=DateTime.Now
                    };
                    db.TblSepet.Add(s);
                        db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            return HttpNotFound();
        }

        public ActionResult SepetCount(int?count)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == User.Identity.Name);
                count=db.TblSepet.Where(x => x.KullaniciId == model.KullaniciId).Count();
                ViewBag.count = count;
                if (count == 0)
                {
                    ViewBag.count = "";
                }
                return PartialView();
            }
            return HttpNotFound();
        }
        public   ActionResult arttir(int id)
        {
            var model = db.TblSepet.Find(id);
            model.Adet++;
            model.Fiyat = model.Fiyat * model.Adet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult azalt(int id)
        {
            var model = db.TblSepet.Find(id);
            if (model.Adet==1)
            {
                db.TblSepet.Remove(model);
                db.SaveChanges();
            }
            model.Adet--;
            model.Fiyat = model.Fiyat * model.Adet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void AdetYaz(int id, int miktari)
        {
            var model = db.TblSepet.Find(id);
          
            model.Adet = miktari;
            model.Fiyat = model.Fiyat * model.Adet;
            db.SaveChanges();
        }
        public ActionResult Sil(int id)
        {
            var Sil = db.TblSepet.Find(id);
            db.TblSepet.Remove(Sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HepsiniSil()
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == kullaniciadi);
                var sil = db.TblSepet.Where(x => x.KullaniciId == model.KullaniciId);
                db.TblSepet.RemoveRange(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}