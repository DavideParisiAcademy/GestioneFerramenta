using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;
using System.Security.Cryptography;

namespace REST_03_EF_ferramenta.Services
{
    public class ProdottoService
    {
        private readonly ProdottoRepository _repository;
        
        public ProdottoService(ProdottoRepository repository)
        {
            _repository = repository;
           
        }

        public List<ProdottoDTO> CercaProdottiPerRepartoId(int id)
        {
            List<ProdottoDTO> risultato = new List<ProdottoDTO>();

            List<Prodotto> prodotti = _repository.GetByRepartoRif(id);
            foreach(Prodotto pro in prodotti)
            {
                ProdottoDTO temp = new ProdottoDTO()
                {
                    Cod = pro.prodottoCOD,
                    Des = pro.Descrizione,
                    Nom = pro.Nome,
                    Pre = pro.Prezzo,
                    Qua = pro.Quantita
                };

                risultato.Add(temp);    
            }

            return risultato;
        }

        public bool InserisciProdotto(ProdottoInsertDTO proDTO)
        {

            Prodotto prodotto = new Prodotto()
            {
                
                prodottoCOD = proDTO.Cod,
                Nome = proDTO.Nom,
                Descrizione = proDTO.Des,
                Prezzo = proDTO.Pre,
                Quantita = proDTO.Qua,
                RepartoRif = proDTO.Rif,

            };

            return _repository.Insert(prodotto);

        }

        public bool EliminaProdottoById(int varID)
        {
            bool risultato = false;

            Prodotto? pro = _repository.GetById(varID);
            if (pro is not null)

                risultato = _repository.Delete(varID);


            return risultato;
        }

        public bool UpdateProdottoService(ProdottoInsertDTO objDto, int varID)
        {
            Prodotto? objProdotto = _repository.GetById(varID);
            Prodotto prodottoLocale = new Prodotto
            {
                Prezzo = objProdotto.Prezzo,
                Descrizione = objProdotto.Descrizione
            };

            if(objProdotto is not null) { 
            if (objDto.Des is not null)
            {
                objProdotto.Descrizione = objDto.Des;
            }
                else
                {
                    objProdotto.Descrizione = prodottoLocale.Descrizione;
                }
            if(objDto.Pre != 0)
            {
                objProdotto.Prezzo = objDto.Pre;
            }
                else
                {
                    objProdotto.Prezzo = prodottoLocale.Prezzo;
                }
            objProdotto.prodottoCOD = objDto.Cod;
            objProdotto.Nome = objDto.Nom;
            objProdotto.Quantita = objDto.Qua;
            objProdotto.RepartoRif = objDto.Rif;
            }

            bool risultato = _repository.Update(objProdotto);
            
            return risultato;
        }
    }
}
