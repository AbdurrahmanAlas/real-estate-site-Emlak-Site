using Emlak2020.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace Emlak2020.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;


            var ilan = db.Ilans.Include(m => m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());
        }


        public ActionResult DurumList(int id)
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;

            var ilan = db.Ilans.Where(i => i.DurumId == id).Include(m => m.Mahalle).Include(e => e.Tip);
            return View(ilan.ToList());

        }




        public ActionResult MenuFiltre(int id)
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;
            var filtre = db.Ilans.Where(i => i.TipId == id).Include(m => m.Mahalle).Include(e => e.Tip).ToList();
            return View(filtre);


        }
        //public PartialViewResult DurumTip1()
        //{

        //    var durumtip1 = db.Tips.Where(i => i.DurumId == 1).ToList();
        //    return PartialView(durumtip1);


        //}



        public PartialViewResult PartialFiltre()
        {
            ViewBag.sehirlist = new SelectList(SehirGetir(), "SehirId", "SehirAd");

            ViewBag.durumlist = new SelectList(DurumGetir(), "DurumId", "DurumAd");
            return PartialView();
        }

        public ActionResult Filtre(int min, int max, int sehirid, int mahalleid, int semtid, int durumid)
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;

            var filtre = db.Ilans.Where(i =>  i.DurumId == durumid
                                           && i.SemtId == semtid
                                           && i.MahalleId == mahalleid
                                           && i.SehirId == sehirid
                                           && i.Fiyat >= min
                                           && i.Fiyat <= max
                                        ).Include(m => m.Mahalle).Include(e => e.Tip).ToList();
            return View(filtre);

        }





        public List<Sehir> SehirGetir()
        {
            List<Sehir> sehirler = db.Sehirs.ToList();

            return sehirler;
        }
        public ActionResult SemtGetir(int SehirId)
        {
            List<Semt> semtlist = db.Semts.Where(x => x.SehirId == SehirId).ToList();
            ViewBag.semtlistesi = new SelectList(semtlist, "SemtId", "SemtAd");

            return PartialView("SemtPartial");
        }

        public ActionResult MahalleGetir(int SemtId)
        {

            List<Mahalle> mahallelist = db.Mahalles.Where(x => x.SemtId == SemtId).ToList();
            ViewBag.mahallelistesi = new SelectList(mahallelist, "MahalleId", "MahalleAd");
            return PartialView("MahallePartial");
        }
        public List<Durum> DurumGetir()
        {

            List<Durum> durumlar = db.Durums.ToList();
            return durumlar;


        }
        public ActionResult TipGetir(int DurumId)
        {
            List<Tip> tiplist = db.Tips.Where(x => x.DurumId == DurumId).ToList();
            ViewBag.tiplistesi = new SelectList(tiplist, "TipId", "TipAd");
            return PartialView("TipPartial");

        }





        public ActionResult Search(string q)
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;

            var ara = db.Ilans.Include(m => m.Mahalle)/*.Include(e=>e.Adres)*/.Include(e => e.Mahalle.Semt).Include(e => e.Tip);
            if (!string.IsNullOrEmpty(q))
            {
                ara = ara.Where(i => i.Açıklama.Contains(q) 
                                  || i.Mahalle.MahalleAd.Contains(q)
                                  || i.Mahalle.Semt.SemtAd.Contains(q)
                                  || i.Tip.TipAd.Contains(q));

            }
            return View(ara.ToList());


        }
        public PartialViewResult Kiralık()
        {
            //var image = db.Resims.ToList();
            //ViewBag.image = image;
            var kiralık = db.Ilans.Where(i => i.DurumId == 1).ToList();
            return PartialView(kiralık);


        }
        public PartialViewResult Satılık()
        {
            var image = db.Resims.ToList();
            ViewBag.image = image;
            var satılık = db.Tips.Where(i => i.TipId == 2).ToList();
            return PartialView(satılık);


        }



        public ActionResult Detay(int id)
        {
            var ilan = db.Ilans.Where(i => i.IlanId == id).Include(m => m.Mahalle).Include(e => e.Tip).FirstOrDefault();
            var image = db.Resims.Where(i => i.IlanId == id).ToList();

            ViewBag.image = image;
            return View(ilan);
        }


        public PartialViewResult Slider()
        {

            var image = db.Resims.ToList();
            ViewBag.image = image;


            var ilan = db.Ilans.ToList().Take(9); 
            return PartialView(ilan);


        }
        public PartialViewResult Kıralık()
        {

            var image = db.Resims.ToList();
            ViewBag.image = image;

            var kiralık = db.Ilans.ToList().Take(9);
            return PartialView(kiralık);


        }
    }

}