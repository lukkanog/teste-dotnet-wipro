﻿using System;
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

                return Ok(new
                {
                    Mensagem = "Filme alugado com sucesso.",
                    Locacao = locacao
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



        [HttpPut("{idLocacao}")]
        public IActionResult Devolver(int idLocacao)
        {
            try
            {
                // Finaliza a locação
                Locacao locacaoFinalizada = locacaoRepository.FinalizarLocacao(idLocacao);

                // Mensagem que será retornada na resposta da requisição.
                string mensagemResposta;

                // Verifica se houve atraso na entrega
                if (locacaoFinalizada.DiasAtrasado > TimeSpan.Zero)
                {
                    mensagemResposta = $"Filme devolvido com atraso de {locacaoFinalizada.DiasAtrasado.Value.Days} dia(s)";
                } else
                {

                    // se não houver atraso, esconder a diferença de dias da resposta
                    locacaoFinalizada.DiasAtrasado = null;
                    mensagemResposta = "Filme devolvido com sucesso dentro do prazo.";
                }

                return Ok(new
                {
                    Mensagem = mensagemResposta,
                    Locacao = locacaoFinalizada
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

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Locacao> locacoes = locacaoRepository.Listar();
                return Ok(locacoes);
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

        [HttpGet("{idLocacao}")]
        public IActionResult BuscarPorId(int idLocacao)
        {
            try
            {
                Locacao locacao = locacaoRepository.BuscarPorId(idLocacao);
                
                //Verifica se locação não existe
                if (locacao == null)
                    return NotFound("Locação não encontrada.");


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

        [HttpGet("filme/{idFilme}")]
        public IActionResult ListarPorFilme(int idFilme)
        {
            try
            {
                List<Locacao> locacoes = locacaoRepository.ListarPorFIlme(idFilme);
                return Ok(locacoes);
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

        [HttpGet("cliente/{idCliente}")]
        public IActionResult ListarPorCliente(int idCliente)
        {
            try
            {
                List<Locacao> locacoes = locacaoRepository.ListarPorUsuario(idCliente);
                return Ok(locacoes);
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
