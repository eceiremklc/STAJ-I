using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class SepetController : Controller
    {
        UrunStokTakipEntities db = new UrunStokTakipEntities();
        // GET: Sepet
        public ActionResult Index(decimal?Tutar)
        {
            if(User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.mail == kullaniciadi);
                var model = db.Sepet.Where(x => x.kullanici_id == kullanici.kullanici_id).ToList();
                var kId = db.Sepet.FirstOrDefault(x => x.kullanici_id==kullanici.kullanici_id);
                if(model!=null)
                {
                    if(kId==null)
                    {
                        ViewBag.Tutar = "Sepetiniz Boş.";
                    }
                    else if(kId!=null)
                    {
                        Tutar = db.Sepet.Where(x => x.kullanici_id == kId.kullanici_id).Sum(x => x.Urunler.urun_fiyat * x.adet);
                        ViewBag.Tutar = "Toplam Tutar =" + Tutar + "TL";
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
                var model = db.Kullanicilar.FirstOrDefault(x => x.mail == kullaniciadi);
                var u = db.Urunler.Find(id);
                var sepet = db.Sepet.FirstOrDefault(x => x.kullanici_id == model.kullanici_id && x.urun_id == id);
                if(model!=null)
                {
                    if (sepet != null)
                    {
                        sepet.adet++;
                        sepet.fiyat = u.urun_fiyat * sepet.adet;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var s = new Sepet
                    {
                        kullanici_id = model.kullanici_id,
                        urun_id=u.urun_id,
                        adet=1,
                        fiyat=u.urun_fiyat,
                        tarih=DateTime.Now
                    };
                    db.Sepet.Add(s);
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
                var model = db.Kullanicilar.FirstOrDefault(x => x.mail == User.Identity.Name);
                count = db.Sepet.Where(x => x.kullanici_id == model.kullanici_id).Count();
                ViewBag.count = count;
                if (count == 0)
                {
                    ViewBag.count = "";
                }
                return PartialView();
            }
            return HttpNotFound();
        }
        public ActionResult arttir(int id)
        {
            var model = db.Sepet.Find(id);
            model = db.Sepet.Where(x => x.urun_id == id).FirstOrDefault();
            model.adet++;
            model.fiyat = model.fiyat * model.adet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult azalt(int id)
        {
            var model = db.Sepet.Find(id);
            model = db.Sepet.Where(x => x.urun_id == id).FirstOrDefault();
            if (model.adet == 1)
            {
                db.Sepet.Remove(model);
                db.SaveChanges();
            }
            model.adet--;
            model.fiyat = model.fiyat * model.adet;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void AdetYaz(int id, int miktari)
        {
            var model = db.Sepet.Find(id);
            model = db.Sepet.Where(x => x.urun_id == id).FirstOrDefault();
            model.adet = miktari;
            model.fiyat = model.fiyat * model.adet;
            db.SaveChanges();
        }

        public ActionResult Sil(int id)
        {
            var sil = db.Sepet.Find(id);
            sil = db.Sepet.Where(x => x.urun_id == id).FirstOrDefault();
            db.Sepet.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SepetiTemizle()
        {
            if(User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.Kullanicilar.FirstOrDefault(x => x.mail == kullaniciadi);
                var sil = db.Sepet.Where(x => x.kullanici_id == model.kullanici_id);
                db.Sepet.RemoveRange(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}