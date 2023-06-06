using Microsoft.EntityFrameworkCore;

namespace WebAppOptika.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create(Naocale naocale)
        {
            _appDbContext.Add(naocale);
            _appDbContext.SaveChanges();
        }

        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }

        public void Delete(Naocale naocale)
        {
            _appDbContext.Remove(naocale);
            _appDbContext.SaveChanges();
        }

        public void Delete(Kategorija kategorija )
        {
            _appDbContext.Remove(kategorija);
            _appDbContext.SaveChanges();
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _appDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public Naocale DohvatiNaocaleSIdom(int id)
        {
            return _appDbContext.Naocale.Include(k => k.Kategorija).FirstOrDefault(f => f.Id == id);
        }


        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }

        public IEnumerable<Naocale> PopisNaocala()
        {
          
                return _appDbContext.Naocale.Include(k => k.Kategorija);
            
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Naocale.Include(k => k.Kategorija).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Naocale naocale)
        {
            _appDbContext.Naocale.Update(naocale);
            _appDbContext.SaveChanges();
        }

        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }

    }
}
