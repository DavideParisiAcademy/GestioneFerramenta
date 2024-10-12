using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;

namespace REST_03_EF_ferramenta.Services
{
    public class RepartoService
    {
        private readonly RepartoRepository _repository;
        
        public RepartoService(RepartoRepository repository)
        {
            _repository = repository;
            
        }

        public RepartoDTO? CercaRepartoPerId(int id)
        {
            RepartoDTO? risultato = null;
            Reparto? reparto = _repository.GetById(id);

            if (reparto is not null) {
                risultato = new RepartoDTO()
                {
                    Cod = reparto.RepartoCod,
                    Fil = reparto.Fila,
                    Nom = reparto.Nome
                };
            }

            return risultato;
        }

        public bool InserisciReparto(RepartoDTO repaDto) 
        {

            Reparto reparto = new Reparto()
            {
                Fila = repaDto.Fil,
                RepartoCod = repaDto.Cod is not null ? repaDto.Cod : Guid.NewGuid().ToString(),
                Nome = repaDto.Nom,
            };

            return _repository.Insert(reparto);

        }


        public bool EliminaRepartoById(int varID)
        {
            bool risultato = false;

            Reparto rep = _repository.GetById(varID);
            if (rep is not null)

                risultato = _repository.Delete(varID);


            return risultato;
        }

        public bool UpdateRepartoService(RepartoUpdateDTO objDto, int varID)
        {
            Reparto? objReparto = _repository.GetById(varID);
            Reparto repartoLocale = new Reparto
            {
               RepartoCod = objReparto.RepartoCod 
            };

            if (objReparto is not null)
            {
                if (objDto.Cod is not null)
                {
                    objReparto.RepartoCod = objDto.Cod;
                }
                else
                {
                    objReparto.RepartoCod = repartoLocale.RepartoCod;
                }

                objReparto.Nome = objDto.Nom;
                objReparto.Fila = objDto.Fil;
            }

            bool risultato = _repository.Update(objReparto);

            return risultato;
        }
    }
}
