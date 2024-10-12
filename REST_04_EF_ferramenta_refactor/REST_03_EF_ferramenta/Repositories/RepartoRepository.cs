using REST_03_EF_ferramenta.Models;

namespace REST_03_EF_ferramenta.Repositories
{
    public class RepartoRepository : IRepository<Reparto>
    {
        private readonly ContextFerramenta _context;
        public RepartoRepository(ContextFerramenta context)
        {     
        _context = context;

        }

        public bool Delete(int id)
        {
            bool risultato = false;

                try
                {
                    Reparto lib = _context.Reparti.Single(l => l.RepartoId == id);
                    _context.Reparti.Remove(lib);
                    _context.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
          

            return risultato;
        }

        public List<Reparto> GetAll()
        {
            List<Reparto> elenco = new List<Reparto>();

           
                elenco = _context.Reparti.ToList();

            return elenco;
        }

        public Reparto? GetById(int id)
        {
            Reparto? risultato = null;

           
                risultato = _context.Reparti.FirstOrDefault(l => l.RepartoId == id);

            return risultato;
        }

        public Reparto? GetByCodice(string varCodice)
        {
            Reparto? risultato = null;

            
                risultato = _context.Reparti.FirstOrDefault(l => l.RepartoCod == varCodice);

            return risultato;
        }

        public bool Insert(Reparto t)
        {
            bool risultato = false;

                try
                {
                    _context.Reparti.Add(t);
                    _context.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return risultato;
        }

        public bool Update(Reparto t)
        {
            bool risultato = false;
            try
            {

                _context.Update(t);
                _context.SaveChanges();
                risultato = true;
                return risultato;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return risultato;
            }
        }
    }
}
