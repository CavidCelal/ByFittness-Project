using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Fitness.ApplicationProject.Models.Business
{
    public class AccountUser
    {
        DbByFitnessEntities db;
        public AccountUser()
        {
            db = new DbByFitnessEntities();
        }
      

        public bool DoLogin(TblKullanici p, out string Mesaj)
        {
            bool result = false;
            Mesaj = "";
            try
            {
                if (p.KullaniciEmail == null || p.Sifre == null)
                {
                    Mesaj = "Kullanıcı bilgileri boş olamaz";
                    return false;
                }


                if (p == null)
                {
                    Mesaj = "Kullanıcı bilgileri boş olamaz";
                   return false;
                }
                else
                {
                    var Bilgiler = db.TblKullanici.FirstOrDefault(x => x.KullaniciEmail == p.KullaniciEmail && x.Sifre == p.Sifre);

                    if (Bilgiler == null)
                    {
                        Mesaj = "Kullanıcı Bilgiler hatalı";
                    }
                    else 
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Mesaj = ex.Message;
            }

            return result;
        }


        public bool DoRegister(TblKullanici Kullanici, out string Mesaj)
        {
            bool result = false;
            Mesaj = "";
            bool ExistsUser()
            {
                bool Exists = false;
                var Kisi = (from data in db.TblKullanici where data.KullaniciEmail == Kullanici.KullaniciEmail select data).FirstOrDefault();
                if (Kisi != null)
                    Exists = true;
                return Exists;
            }

           
            try
            {
                TblKullanici Kisi = Kullanici;
                

                if (!ExistsUser())
                {
                    
                   
                    db.TblKullanici.Add(Kisi);
                    Kullanici.Roller = "User";
                    db.SaveChanges();
                    result = true;


                }

            }
            catch (Exception)
            {
                Mesaj = "Hata meydana geldi.";
              
            }
            return result;
        }
      

    }
}