namespace WebAppOptika.Models
{
    public interface IRepozitorijUpita
    {


        IEnumerable<Naocale> PopisNaocala();
        void Create(Naocale naocale);
        void Delete(Naocale naocale);
        void Update(Naocale naocale);
        int SljedeciId();
        
        Naocale DohvatiNaocaleSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);
        Kategorija DohvatiKategorijuSIdom(int id);
        int KategorijaSljedeciId();
      
    }
}
