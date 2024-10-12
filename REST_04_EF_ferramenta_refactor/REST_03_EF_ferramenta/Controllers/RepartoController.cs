using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta.Controllers
{
    [ApiController]
    [Route("api/reparto")]
    public class RepartoController : Controller
    {
        private readonly RepartoService _service;
        private readonly ProdRepaService _prodRepaService;

        public RepartoController(RepartoService service, ProdRepaService prodRepaService)
        {
            _service = service;
            _prodRepaService = prodRepaService;
        }

        [HttpPost]
        public IActionResult InserisciReparto(RepartoDTO objDto)
        {
            if(string.IsNullOrWhiteSpace(objDto.Nom) || string.IsNullOrWhiteSpace(objDto.Fil))
                return BadRequest();

            bool risultato =_service.InserisciReparto(objDto);

            if (risultato)
                return Ok();

            return BadRequest();
        }

        [HttpGet("{varCodice}")]
        public ActionResult<RepartoDTO?> CercaReparto(string varCodice)
        {
            RepartoDTO? risultato =_prodRepaService.CercaRepartoPerCodice(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet("reparto-by-id/{varID}")]

        public ActionResult<RepartoDTO> cercaRepartoById(int varID)
        {
            if(varID < 0)
                return BadRequest();
            RepartoDTO? risultato = _service.CercaRepartoPerId(varID);
            return Ok(risultato);
        }

        [HttpDelete("elimina-by-id/{varID}")]

        public ActionResult<bool> EliminaById(int varID)
        {

            if (int.IsNegative(varID))
                return BadRequest();

            if (_service.EliminaRepartoById(varID))
                return Ok();

            return NotFound();
        }

        [HttpPatch("{varID}")]
        public ActionResult<bool> UpdateReparto(RepartoUpdateDTO objDto, int varID)
        {
            if (int.IsNegative(varID))
                return BadRequest();
            if (string.IsNullOrEmpty(objDto.Nom) || string.IsNullOrEmpty(objDto.Fil))
                return BadRequest();

            bool risultato = _service.UpdateRepartoService(objDto, varID);

            return risultato;
        }
    }

}

