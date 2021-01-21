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
                    var response = new
                    {
                        Erro = true,
                        Mensagem = "Usuário já existe."
                    };

                    return BadRequest(response);
                }
                    

                clienteRepository.CadastrarCliente(cliente);
                return Ok("Cliente cadastrado com sucesso");
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
