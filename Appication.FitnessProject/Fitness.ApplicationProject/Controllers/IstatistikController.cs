using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbByFitnessEntities db = new DbByFitnessEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satis = db.TblSatislar.Count();
            ViewBag.satis = satis;
            var urun = db.TblUrun.Count();
            ViewBag.urun = urun;    
            var kategori = db.TblKategori.Count();
            ViewBag.kategori = kategori;
            var sepet = db.TblSepet.Count();
            ViewBag.sepet = sepet;
            var kullanici = db.TblKullanici.Count();
            ViewBag.kullanici = kullanici;
           
            return View();
        }
    }
}