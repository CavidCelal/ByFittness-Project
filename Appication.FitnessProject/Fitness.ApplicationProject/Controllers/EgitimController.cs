
using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbByFitnessEntities db = new DbByFitnessEntities();
        [Authorize]
        public ActionResult Index(string ara)
        {

            var list = db.TblEgitim.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list=list.Where(x => x.EgitimAdi.Contains(ara) || x.Aciklama.Contains(ara)).ToList();

            }
            return View(list);
        }

        [Authorize(Roles = "A")]
        public ActionResult Ekle()
        {
            List<SelectListItem> deger1 = (from data in db.TblEgitimKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text=data.EgitimKategoriAdi,
                                               Value=data.EgitimKategoriId.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;

            return View();
        }
       
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult Ekle(TblEgitim Data, HttpPostedFileBase File)
        {
            //var coach = new TblCoach(); 
            string path = Path.Combine("~/assets/images"+File.FileName);
            File.SaveAs(Server.MapPath(path));
            Data.EgitimResmi = File.FileName.ToString();
            db.TblEgitim.Add(Data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult Sil(int id)
        {
            var egitim = db.TblEgitim.Where(x => x.EgitimId == id).FirstOrDefault();
            db.TblEgitim.Remove(egitim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.TblEgitim.Where(x => x.EgitimId == id).FirstOrDefault();
            List<SelectListItem> deger1 = (from x in db.TblEgitimKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.EgitimKategoriAdi,
                                               Value=x.EgitimKategoriId.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View(guncelle);
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult Guncelle(TblEgitim data, HttpPostedFileBase FileName)
        {
            var Egitim = db.TblEgitim.Find(data.EgitimId);

            if (FileName == null)
            {


                Egitim.EgitimAdi = data.EgitimAdi;
                Egitim.Aciklama = data.Aciklama;
                Egitim.EgitimKategoriId = data.EgitimKategoriId;
                Egitim.EgitimFiyat = data.EgitimFiyat;
                Egitim.EgitimGunleri = data.EgitimGunleri;
                Egitim.EgitimSaat = data.EgitimSaat;              
                Egitim.CoachAdi = data.CoachAdi;
                Egitim.CoachCinsi = data.CoachCinsi;
                Egitim.CoachDogumTarih = data.CoachDogumTarih;
                Egitim.CoachTel = data.CoachTel;
                Egitim.CoachEmail = data.CoachEmail;
               
               
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                Egitim.EgitimAdi = data.EgitimAdi;
                Egitim.Aciklama = data.Aciklama;
                Egitim.EgitimKategoriId = data.EgitimKategoriId;
                Egitim.EgitimFiyat = data.EgitimFiyat;
                Egitim.EgitimGunleri = data.EgitimGunleri;
                Egitim.EgitimSaat = data.EgitimSaat;
                Egitim.EgitimResmi = FileName.FileName.ToString();
                Egitim.CoachAdi = data.CoachAdi;
                Egitim.CoachCinsi = data.CoachCinsi;
                Egitim.CoachDogumTarih = data.CoachDogumTarih;
                Egitim.CoachTel = data.CoachTel;
                Egitim.CoachEmail = data.CoachEmail;

                db.SaveChanges();
                return RedirectToAction("Index");


            }
           
        }
    }
}