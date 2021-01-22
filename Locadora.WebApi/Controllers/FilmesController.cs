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
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository filmeRepository { get; set; }

        public FilmesController()
        {
            filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult ListarFilmes()
        {
            try
            {
                List<Filme> lista = filmeRepository.ListarFilmes();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(new { 
                    Erro = true,
                    Mensagem = e.Message
                });
            }
        }


        [HttpPost]
        public IActionResult CadastrarFilme(Filme filme)
        {
            try
            {
                filmeRepository.CadastrarFilme(filme);
                return Ok(new
                {
                    Mensagem = "Filme cadastrado com sucesso.",
                    Filme = filme
                });
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
