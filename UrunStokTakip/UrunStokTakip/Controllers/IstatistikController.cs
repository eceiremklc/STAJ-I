using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    [Authorize(Roles ="A")]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        UrunStokTakipEntities db = new UrunStokTakipEntities();
        public ActionResult Index()
        {
            var deger1 = db.Urunler.Count().ToString();
            ViewBag.urun = deger1;
            var deger2 = db.Kullanicilar.Count().ToString();
            ViewBag.musteri = deger2;
            var deger3 = db.Kategori.Count().ToString();
            ViewBag.kategori = deger3;
            var deger4 = db.Urunler.Where(x => x.urun_id == (db.Satislar.GroupBy(y => y.urun_id)
            .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()))
                .Select(k => k.urun_adi).FirstOrDefault();
            ViewBag.enurun = deger4;
            var deger5 = db.Kullanicilar.Where(x => x.kullanici_id == (db.Satislar.GroupBy(y => y.kullanici_id)
              .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()))
                .Select(k => k.ad + " " + k.soyad).FirstOrDefault();
            ViewBag.enmusteri = deger5;
            var deger6 = db.Satislar.Sum(x => x.fiyat).ToString();
            ViewBag.kasa = deger6;
            DateTime bugun = DateTime.Today;
            var deger7 = db.Satislar.Where(x => x.tarih == bugun).Sum(y => y.fiyat).ToString();
            ViewBag.bugun = deger7;
            return View();
        }
    }
}