using Fitness.ApplicationProject.Models.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Fitness.ApplicationProject.Models.Business;

namespace Fitness.ApplicationProject.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbByFitnessEntities db =  new DbByFitnessEntities();
       
        [Authorize]
        public ActionResult Index(string Ara)
        {
           
            ;
            var list = db.TblUrun.ToList();
            if (!string.IsNullOrEmpty(Ara))
            {
                list=list.Where(x => x.UrunAdi.Contains(Ara) || x.Aciklama.Contains(Ara)).ToList();

            }
            return View(list);
        }
        [Authorize(Roles = "A")]
        public ActionResult Ekle()
        {

            List<SelectListItem> deger1 = (from data in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text=data.KategoriAdi,
                                               Value=data.KategoriId.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View();
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult Ekle(TblUrun Data, HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Content/Image"+File.FileName);
            File.SaveAs(Server.MapPath(path));
            Data.Resim = File.FileName.ToString();
            db.TblUrun.Add(Data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
         
            var urun = db.TblUrun.Where(x => x.UrunId == id).FirstOrDefault();
            db.TblUrun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public  ActionResult Guncelle(int id)
        {
            var guncelle = db.TblUrun.Where(x => x.UrunId == id).FirstOrDefault();
            List<SelectListItem> deger1 = (from x in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.KategoriAdi,
                                               Value=x.KategoriId.ToString()
                                           }).ToList();

            ViewBag.ktgr = deger1;
            return View(guncelle);
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult Guncelle(TblUrun data, HttpPostedFileBase FileName)
        {

            //var urun = db.TblUrun.Where(x => x.UrunId == data.UrunId).FirstOrDefault();
            var urun = db.TblUrun.Find(data.UrunId);

            if (FileName == null)
            {


                urun.UrunAdi = data.UrunAdi;
                urun.Aciklama = data.Aciklama;
                urun.Fiyat = data.Fiyat;
                urun.Stok = data.Stok;
                urun.Populer = data.Populer;
                urun.KategoriId = data.KategoriId;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                urun.Resim = FileName.FileName.ToString();
                urun.UrunAdi = data.UrunAdi;
                urun.Aciklama = data.Aciklama;
                urun.Fiyat = data.Fiyat;
                urun.Stok = data.Stok;
                urun.Populer = data.Populer;
                urun.KategoriId = data.KategoriId;
                db.SaveChanges();
                return RedirectToAction("Index");


            }


        }
        [Authorize(Roles = "A")]
        public ActionResult KritikStok()
        {
            var kritik = db.TblUrun.Where(x => x.Stok <= 50).ToList();
            return View(kritik);
        }
        public PartialViewResult StokCount()
        {
            if (User.Identity.IsAuthenticated)
            {
                var count = db.TblUrun.Where(x=>x.Stok < 50).Count();
                ViewBag.count = count;
                var azalan = db.TblUrun.Where(x => x.Stok == 50).Count();
                ViewBag.azalan = azalan;
            }
            return PartialView();
        }
        public ActionResult StokGrafik()
        {
            ArrayList deger1 = new ArrayList();
            ArrayList deger2 = new ArrayList();
            var veriler = db.TblUrun.ToList();
            veriler.ToList().ForEach(x => deger1.Add(x.UrunAdi));
            veriler.ToList().ForEach(x => deger2.Add(x.Stok));
            var grafik = new Chart(width: 500, height: 500).AddTitle("Ürün-Stok-Grafiği").AddSeries(chartType: "Column", name: "UrunAdi", xValue: deger1, yValues: deger2);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");

        }
    }
}