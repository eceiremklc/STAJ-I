using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;
using PagedList;
using PagedList.Mvc;

namespace UrunStokTakip.Controllers
{
    public class SatisController : Controller
    {
        UrunStokTakipEntities db = new UrunStokTakipEntities();
        // GET: Satis
        public ActionResult Index(int sayfa=1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.mail == kullaniciadi);
                var model = db.Satislar.Where(x => x.kullanici_id == kullanici.kullanici_id).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return HttpNotFound();
        }
        public ActionResult SatinAl(int id)
        {
            var model = db.Sepet.FirstOrDefault(x => x.urun_id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult SatinAl2(Satislar s)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Sepet.Where(x => x.urun_id == s.urun_id).FirstOrDefault();
                    
                    var satis = new Satislar
                    {
                        kullanici_id = model.kullanici_id,
                        urun_id = model.urun_id,
                        adet = model.adet,
                        resim = model.resim,
                        fiyat = model.fiyat,
                        tarih = model.tarih,
                    };

                    db.Sepet.Remove(model);
                    db.Satislar.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satın alma işlemi başarılı.";
                }
            }
            catch (Exception)
            {
                ViewBag.islem = "Satın alma işlemi başarısız.";
            }
            return View("islem");
        }
        
        public ActionResult SepetiOnayla(decimal?Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.mail == kullaniciadi);
                var model = db.Sepet.Where(x => x.kullanici_id == kullanici.kullanici_id).ToList();
                var kId = db.Sepet.FirstOrDefault(x => x.kullanici_id == kullanici.kullanici_id);
                if (model != null)
                {
                    if (kId == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmamaktadır.";
                    }else if (kId != null)
                    {
                        Tutar = db.Sepet.Where(x => x.kullanici_id == kId.kullanici_id).Sum(x => x.Urunler.urun_fiyat * x.adet);
                        ViewBag.Tutar = "Toplam Tutar = " + Tutar + "TL";
                    }
                    return View(model);
                }
                return View();
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult SepetiOnayla2()
        {
            var username = User.Identity.Name;
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.mail == username);
            var model = db.Sepet.Where(x => x.kullanici_id == kullanici.kullanici_id).ToList();
            int satir = 0;

            foreach(var item in model)
            {
                var satis = new Satislar
                {
                    kullanici_id = model[satir].kullanici_id,
                    urun_id = model[satir].urun_id,
                    adet = model[satir].adet,
                    fiyat = model[satir].fiyat,
                    resim = model[satir].resim,
                    tarih = DateTime.Now
                };
                db.Satislar.Add(satis);
                db.SaveChanges();
                satir++;
            }
            db.Sepet.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Sepet");

        }
    }
}