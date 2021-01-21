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
                clienteRepository.CadastrarCliente(cliente);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception e)
            {
                var response = new {
                    Erro = true,
                    Mensagem = e.Message
                };

                return BadRequest(response);
            }
        }
    }
}
