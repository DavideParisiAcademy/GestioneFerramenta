using REST_03_EF_ferramenta.Models;

namespace REST_03_EF_ferramenta.Repositories
{
    public class ProdottoRepository : IRepository<Prodotto>
    {
        private readonly ContextFerramenta _context;

        public ProdottoRepository(ContextFerramenta context)
        {
            _context = context;
        }
        

        public bool Delete(int id)
        {
            bool risultato = false;

                try
                {
                    Prodotto lib = _context.Prodotti.Single(l => l.ProdottoId == id);
                    _context.Prodotti.Remove(lib);
                    _context.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return risultato;
        }

        public List<Prodotto> GetAll()
        {
            List<Prodotto> elenco = new List<Prodotto>();

                elenco = _context.Prodotti.ToList();

            return elenco;
        }

        public Prodotto? GetById(int id)
        {
            Prodotto? risultato = null;

                risultato = _context.Prodotti.FirstOrDefault(l => l.ProdottoId == id);

            return risultato;
        }

        public Prodotto? GetByCodiceBarre(string varCodice)
        {
            Prodotto? risultato = null;

                risultato = _context.Prodotti.FirstOrDefault(l => l.prodottoCOD == varCodice);

            return risultato;
        }

        public List<Prodotto> GetByRepartoRif(int rif)
        {
            List<Prodotto> risultato = new List<Prodotto>();

            
                risultato = _context.Prodotti.Where(l => l.RepartoRif == rif).ToList();

            return risultato;
        }

        public bool Insert(Prodotto t)
        {
            bool risultato = false;

                try
                {
                    _context.Prodotti.Add(t);
                    _context.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
           

            return risultato;
        }

        public bool Update(Prodotto t)
        {
            bool risultato = false;
            try {

                _context.Update(t);
                _context.SaveChanges();
                risultato= true;
                return risultato;
                    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return risultato;
            }

        }
    }
}
