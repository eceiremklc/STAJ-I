using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    [Authorize(Roles = "A")]
    public class KategoriController : Controller
    {
        // GET: Kategori
        UrunStokTakipEntities db = new UrunStokTakipEntities();

        public ActionResult Index()
        {
            return View(db.Kategori.Where(x => x.durum == true).ToList());
        }


        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Ekle(Kategori data)
        {
            db.Kategori.Add(data);
            data.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.Kategori.Where(x => x.kategori_id == id).FirstOrDefault();
            db.Kategori.Remove(kategori);
            kategori.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(Kategori data, int id)
        {
            Kategori guncelle = db.Kategori.Find(data.kategori_id);
            guncelle = db.Kategori.Where(x => x.kategori_id == id).FirstOrDefault();
            guncelle.kategori_aciklama = data.kategori_aciklama;
            guncelle.kategori_adi = data.kategori_adi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}