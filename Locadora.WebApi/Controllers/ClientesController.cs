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
    public class ClientesController : ControllerBase
    {
        private IClienteRepository clienteRepository { get; set; }

        public ClientesController()
        {
            clienteRepository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            try
            {
                if (clienteRepository.BuscarPorEmail(cliente.Email) != null)
                {
                    // Se usuário já existe, retornar mensagem de erro.
                    return BadRequest(new
                    {
                        Erro = true,
                        Mensagem = "Usuário já existe."
                    });
                }

                clienteRepository.CadastrarCliente(cliente);

                return Ok(new
                {
                    Mensagem = "Cliente cadastrado com sucesso.",
                    Cliente = cliente
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
