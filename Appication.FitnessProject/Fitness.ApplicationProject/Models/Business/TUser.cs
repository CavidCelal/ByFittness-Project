using Fitness.ApplicationProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Fitness.ApplicationProject.Models.Business
{
    public class TUser
    {
        DbByFitnessEntities db;
        public TUser()
        {
            db = new DbByFitnessEntities();
        }
        public bool SifreReset(string eposta)
        {
            bool result = false;

            try
            {
                var mail = db.TblKullanici.Where(x => x.KullaniciEmail == eposta).SingleOrDefault();
                if (mail != null)
                {
                    Random rnd = new Random();
                    int yenisifre = rnd.Next();
                    TblKullanici sifre = new TblKullanici();
                    mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre), "MD5");
                    db.SaveChanges();
                    WebMail.SmtpServer = "smtp.gmail.com";
                    WebMail.EnableSsl = true;
                    WebMail.UserName = "calalcavlan@gmail.com";
                    WebMail.Password = "Javlon2003Kozirki";
                    WebMail.SmtpPort = 587;
                    WebMail.Send(eposta, "Giriş Şifreniz", "Şifreniz" + yenisifre);
                    result = true;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }      
                    
            return result;

        }
    }
}