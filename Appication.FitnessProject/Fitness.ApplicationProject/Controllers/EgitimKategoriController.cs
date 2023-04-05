using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize(Roles = "A")]
    public class EgitimKategoriController : Controller
    {
        // GET: EgitimKategori
        DbByFitnessEntities db = new DbByFitnessEntities();

        public ActionResult Index()
        {
            return View(db.TblEgitimKategori.ToList());
        }
        //[Authorize(Roles = "A")]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "A")]
        public ActionResult Ekle(TblEgitimKategori data)
        {
            db.TblEgitimKategori.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
            var Egitimkategori = db.TblEgitimKategori.Where(x => x.EgitimKategoriId == id).FirstOrDefault();
            db.TblEgitimKategori.Remove(Egitimkategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.TblEgitimKategori.Where(x => x.EgitimKategoriId == id).FirstOrDefault();
            return View(guncelle);
        }
        [HttpPost]
        public ActionResult Guncelle(TblEgitimKategori data)
        {
            //var guncelle = db.TblKategori.Where(x => x.KategoriId == data.KategoriId).FirstOrDefault();
            var Kategori = db.TblEgitimKategori.Find(data.EgitimKategoriId);

            Kategori.EgitimKategoriAdi = data.EgitimKategoriAdi;
            Kategori.Aciklama =  data.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}