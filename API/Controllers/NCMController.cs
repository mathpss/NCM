using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCM_API.Models;
using NCM_API.Service.Interfaces;

namespace NCM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NCMController : ControllerBase
    {
        private readonly INCMService _ncmService;

        public NCMController(INCMService ncmService)
        {
            _ncmService = ncmService;
        }

        [HttpGet("{ncm}")]
        public ActionResult<Nomenclatura> ObterNCM(string ncm)
        {
            var ncmresponse = _ncmService.BuscarNCM(ncm);
            if (string.IsNullOrEmpty(ncmresponse.Codigo)) return NotFound();
            return Ok(ncmresponse);
        }
        

        [HttpGet("Palavra/{texto}")]
        public ActionResult<List<Nomenclatura>> BucaPorPalavras(string texto)
        {
            var ncmresponse = _ncmService.BuscaPorPalavras(texto);
            
            if (ncmresponse == null || ncmresponse.Count == 0 ) return NotFound();
            return Ok(ncmresponse);
        }
        

        [HttpGet("4Digitos/{texto}")]
        public ActionResult<List<Nomenclatura>> BuscaPor4Digitos(string texto)
        {
            var ncmresponse = _ncmService.BuscaPor4Digitos(texto);
            
            if (ncmresponse == null || ncmresponse.Count == 0 ) return NotFound();
            return Ok(ncmresponse);
        }
        
    }
}