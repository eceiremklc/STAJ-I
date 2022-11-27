using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        UrunStokTakipEntities db = new UrunStokTakipEntities();


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
        public ActionResult Login(Kullanicilar p)
        {
            var bilgiler = db.Kullanicilar.FirstOrDefault(x => x.mail == p.mail && x.sifre == p.sifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
                Session["Mail"] = bilgiler.mail.ToString();
                Session["Ad"] = bilgiler.ad.ToString();
                Session["Soyad"] = bilgiler.soyad.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Kullanicilar data)
        {
            db.Kullanicilar.Add(data);
            data.rol = "U";
            db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Guncelle()
        {
            var kullanicilar = (string)Session["Mail"];
           
            
            var degerler = db.Kullanicilar.FirstOrDefault(x => x.mail == kullanicilar);
            return View(degerler);
        }

        public ActionResult Guncelle2(Kullanicilar data)
        {
            var kullanicilar = (string)Session["Mail"];

            Kullanicilar user = db.Kullanicilar.Find(data);
            user = db.Kullanicilar.Where(x => x.mail == kullanicilar).FirstOrDefault();

            user.ad = data.ad;
            user.soyad = data.soyad;
            user.mail = data.mail;
            user.kullanici_adi = data.kullanici_adi;
            user.sifre = data.sifre;
            user.sifre_tekrar = data.sifre_tekrar;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}