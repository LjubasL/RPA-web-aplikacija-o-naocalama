using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using WebAppOptika.Models;

namespace WebAppOptika.Controllers
{
    public class NaocaleController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public NaocaleController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisNaocala());
        }

        
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "VrstaNaocala");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Naocale naocale = new Naocale() { Id = sljedeciId };
            return View(naocale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,NazivNaocala,MarkaNaocala,Cijena,SlikaUrl,KategorijaId")] Naocale naocale)
        {
            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(naocale);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "VrstaNaocala", naocale.KategorijaId);
            return View(naocale);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var naocale = _repozitorijUpita.DohvatiNaocaleSIdom(Convert.ToInt16(id));

            if (naocale == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "VrstaNaocala", naocale.KategorijaId );
            return View(naocale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,NazivNaocala,MarkaNAocala,Cijena,SlikaUrl,KategorijaId")] Naocale naocale)
        {
            if (id != naocale.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Kategorija");
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(naocale);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "VrstaNaocala", naocale.KategorijaId);
            return View(naocale);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var naocale = _repozitorijUpita.DohvatiNaocaleSIdom(Convert.ToInt16(id));
            if (naocale == null)
            {
                return NotFound();
            }
            return View(naocale);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var naocale = _repozitorijUpita.DohvatiNaocaleSIdom(id);
            _repozitorijUpita.Delete(naocale);
            return RedirectToAction("Index");
        }

        public ActionResult SearchIndex(string naocaleVrsta, string searchString)
        {
            var vrsta = new List<string>();
            var vrstaUpit = _repozitorijUpita.PopisKategorija().Select(x => x.VrstaNaocala);
            ViewBag.naocaleVrsta = new SelectList(vrstaUpit);

            var naocale = _repozitorijUpita.PopisNaocala();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                naocale = naocale.Where(s => s.NazivNaocala.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(naocaleVrsta))
            {
                return View(naocale);
            }
            else
            {
                return View(naocale.Where(x => x.Kategorija.VrstaNaocala == naocaleVrsta));
            }
        }

    }
    }



 
