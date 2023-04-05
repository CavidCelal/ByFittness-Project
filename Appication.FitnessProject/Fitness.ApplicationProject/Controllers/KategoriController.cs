using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize(Roles = "A")]
    public class KategoriController : Controller
    {
        DbByFitnessEntities db = new DbByFitnessEntities();
        //[Authorize(Roles = "A")]
        // GET: Kategori
        public ActionResult Index()
        {
            return View(db.TblKategori.Where(x=>x.Durum== true).ToList());
        }
        //[Authorize(Roles = "A")]
        public   ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "A")]
        public ActionResult Ekle(TblKategori data)
        {
            db.TblKategori.Add(data);
            data.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategori.Where(x => x.KategoriId == id).FirstOrDefault();
            db.TblKategori.Remove(kategori);
            kategori.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult Guncelle(int id)
        {
            var guncelle = db.TblKategori.Where(x => x.KategoriId == id).FirstOrDefault();
            return View(guncelle);
        }
        [HttpPost]
        public ActionResult Guncelle(TblKategori data )
        {
            //var guncelle = db.TblKategori.Where(x => x.KategoriId == data.KategoriId).FirstOrDefault();
            var urun = db.TblKategori.Find(data.KategoriId);

            urun.KategoriAdi = data.KategoriAdi;
            urun.Aciklama =  data.Aciklama;      
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       


        }
    }
