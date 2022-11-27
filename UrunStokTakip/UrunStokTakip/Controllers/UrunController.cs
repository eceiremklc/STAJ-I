using Rotativa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        UrunStokTakipEntities db = new UrunStokTakipEntities();
        [Authorize]
        public ActionResult Index(string ara)
        {
            var list = db.Urunler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.urun_adi.Contains(ara) || x.urun_detay.Contains(ara)).ToList();
            }
            return View(list);
        }
        public ActionResult PrintPDF()
        {
            UrunStokTakipEntities context = new UrunStokTakipEntities();
            List<Urunler> Data = context.Urunler.ToList();

            return new PartialViewAsPdf("PrintPDF", Data)
            {
                FileName = "Urunler.pdf"
            };
        }
        [Authorize(Roles ="A")]
        public ActionResult Ekle()
        {
            List<SelectListItem> deger1 = (from x in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategori_adi,
                                               Value = x.kategori_id.ToString()
                                           }).ToList();

            ViewBag.ktgr = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Urunler Data, HttpPostedFileBase File)
        {
            string path = Path.Combine("~/Content/Image" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            Data.resim = File.FileName.ToString();
            db.Urunler.Add(Data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Where(x => x.urun_id == id).FirstOrDefault();
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var guncelle = db.Urunler.Where(x => x.urun_id == id).FirstOrDefault();
            List<SelectListItem> deger1 = (from x in db.Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategori_adi,
                                               Value = x.kategori_id.ToString()
                                           }).ToList();

            ViewBag.ktgr = deger1;
            return View(guncelle);
        }
        [Authorize(Roles = "A")]
        [HttpPost]
        public ActionResult Guncelle(Urunler model, HttpPostedFileBase File, int id)
        {
            Urunler urun = db.Urunler.Find(model.urun_id);
            urun = db.Urunler.Where(x => x.urun_id == id).FirstOrDefault();
           
         
            if (File == null)
            {
                urun.urun_adi = model.urun_adi;
                urun.urun_detay = model.urun_detay;
                urun.urun_fiyat = model.urun_fiyat;
                urun.stok = model.stok;
                urun.populerlik = model.populerlik;
                urun.kategori_id = model.kategori_id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                urun.resim = File.FileName.ToString();
                urun.urun_adi = model.urun_adi;
                urun.urun_detay = model.urun_detay;
                urun.urun_fiyat = model.urun_fiyat;
                urun.stok = model.stok;
                urun.populerlik = model.populerlik;
                urun.kategori_id = model.kategori_id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [Authorize(Roles = "A")]
        public ActionResult KritikStok()
        {
            var kritik = db.Urunler.Where(x => x.stok <= 50).ToList();
            return View(kritik);
        }
        public PartialViewResult StokCount()
        {
            if (User.Identity.IsAuthenticated)
            {
                var count = db.Urunler.Where(x => x.stok < 50).Count();
                ViewBag.count = count;
                var azalan = db.Urunler.Where(x => x.stok == 50).Count();
                ViewBag.azalan = azalan;
            }
            return PartialView();
        }
        public ActionResult StokGrafik()
        {
            ArrayList deger1 = new ArrayList();
            ArrayList deger2 = new ArrayList();
            var veriler = db.Urunler.ToList();
            veriler.ToList().ForEach(x => deger1.Add(x.urun_adi));
            veriler.ToList().ForEach(x => deger2.Add(x.stok));
            var grafik = new Chart(width:800, height:800).AddTitle("Ürün Stok Grafiği")
                .AddSeries(chartType:"Column",name:"urun_adi",xValue:deger1, yValues:deger2);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}