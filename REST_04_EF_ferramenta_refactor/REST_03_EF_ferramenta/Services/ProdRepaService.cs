using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;

namespace REST_03_EF_ferramenta.Services
{
    public class ProdRepaService
    {
        private readonly ProdottoService _prodottoService;
        private readonly RepartoService _repartoService;
        private readonly ProdottoRepository _prodottoRepository;
        private readonly RepartoRepository _repartoRepository;

        public ProdRepaService(ProdottoService service, RepartoService Service, ProdottoRepository prodottoRepository, RepartoRepository repartoRepository)
        {
            _prodottoService = service;
            _repartoService = Service;
            _prodottoRepository = prodottoRepository;
            _repartoRepository = repartoRepository;
        }

        public ProdottoDTO? CercaProdotto(string varCodi)
        {
            ProdottoDTO? risultato = null;

            Prodotto? prod = _prodottoRepository.GetByCodiceBarre(varCodi);
            if (prod is not null)
            {
                risultato = new ProdottoDTO()
                {
                    Cod = prod.prodottoCOD,
                    Des = prod.Descrizione,
                    Nom = prod.Nome,
                    Pre = prod.Prezzo,
                    Qua = prod.Quantita,
                    Rep = _repartoService.CercaRepartoPerId(prod.RepartoRif)
                };
            }

            return risultato;
        }


        public RepartoDTO? CercaRepartoPerCodice(string varCod)
        {
            RepartoDTO? risultato = null;

            Reparto? repa = _repartoRepository.GetByCodice(varCod);
            {
                risultato = new RepartoDTO()
                {
                    Cod = repa.RepartoCod,
                    Fil = repa.Fila,
                    Nom = repa.Nome,
                    Ele = _prodottoService.CercaProdottiPerRepartoId(repa.RepartoId)

                };
            }

            return risultato;
        }

    }
}
