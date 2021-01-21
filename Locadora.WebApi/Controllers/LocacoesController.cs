using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Locadora.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LocacoesController : ControllerBase
    {
        private ILocacaoRepository locacaoRepository { get; set; }

        public LocacoesController()
        {
            locacaoRepository = new LocacaoRepository();
        }

        [HttpPost]
        public IActionResult AlugarFilme(Locacao locacao)
        {
            try
            {
                locacaoRepository.CadastrarLocacao(locacao);
                return Ok(locacao);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Erro = true,
                    Mensagem = e.Message
                });
            }
        }
    }
}
