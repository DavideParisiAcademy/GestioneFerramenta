using Microsoft.AspNetCore.Mvc;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotto")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;
        private readonly ProdRepaService _prodRepaService;

        public ProdottoController(ProdottoService service, ProdRepaService prodRepaService)
        {
            _service = service;
            _prodRepaService = prodRepaService;
        }

        [HttpGet("prodotto/{varCodice}")]
        public ActionResult<ProdottoDTO?> Cerca(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            ProdottoDTO? prod = _prodRepaService.CercaProdotto(varCodice);
            if(prod is not null)
                return Ok(prod);

            return NotFound();
        }

        [HttpGet("prodotto-by-reparto/{varID}")]

        public ActionResult<List<ProdottoDTO>> CercaProdottiByReparto(int varID)
        {
            if(varID < 0)
                return BadRequest();

            List<ProdottoDTO> lista = _service.CercaProdottiPerRepartoId(varID);

            return lista;
        }

        [HttpPost]

        public IActionResult InserisciReparto(ProdottoInsertDTO objDto)
        {
            if (string.IsNullOrWhiteSpace(objDto.Nom) || string.IsNullOrWhiteSpace(objDto.Cod))
                return BadRequest();
            if(int.IsNegative(objDto.Qua))
                return BadRequest();

            bool risultato = _service.InserisciProdotto(objDto);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        [HttpDelete("elimina-by-id/{varID}")]

        public ActionResult<bool> EliminaById(int varID)
        {

            if (int.IsNegative(varID))
                return BadRequest();

            if (_service.EliminaProdottoById(varID))
                return Ok();

            return NotFound();
        }
        [HttpPatch("{varID}")]

        public ActionResult<bool> UpdateProdotto(ProdottoInsertDTO objDto, int varID)
        {
            if (int.IsNegative(varID) || int.IsNegative(objDto.Qua) || int.IsNegative(objDto.Rif))
                return BadRequest();
            if (string.IsNullOrEmpty(objDto.Nom) || string.IsNullOrEmpty(objDto.Cod) || objDto.Qua == 0 || objDto.Rif == 0)
                return BadRequest();

            bool risultato = _service.UpdateProdottoService(objDto, varID);
            
            return risultato;
        }
    }
}
