using Microsoft.AspNetCore.Mvc;
using Sube2.KitapMVC.Models;
using Sube2.KitapMVC.Models.ViewModels;

namespace Sube2.KitapMVC.Controllers
{
    public class KitapController : Controller
    {
        public IActionResult Index()
        {
            List<Kitap> list = null;
            using (var ctx = new KitapDbContext())
            {
                list = ctx.Kitaplar.ToList();
            }
            return View(list);
        }

        public ViewResult KitapDetay()
        {
            dynamic kitap = new Kitap();
            kitap.Ad = "Suç ve Ceza";
            kitap.Yazar = "Dostoyevski";

            var yayinevi = new Yayinevi();
            yayinevi.Ad = "İş Bankası Kültür Yayınları";
            yayinevi.Sehir = "İstanbul";

            
            ViewData["Kitap"] = kitap;
            ViewBag.Book = kitap;

            var vm = new DetayViewModel();
            vm.Yayinevi = yayinevi;
            vm.Kitap = kitap;

            return View("Detay", vm);
        }
        [HttpPost]
        public ViewResult KitapEkle(Kitap kitap)
        {
            using (var ctx = new KitapDbContext())
            {
                ctx.Kitaplar.Add(kitap);
                ctx.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ViewResult KitapEkle()
        {
            return View();
        }
    }
}
