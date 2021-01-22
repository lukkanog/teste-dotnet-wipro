using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Locadora.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Locadora.WebApi.Tests.XUnit.Repositories
{
    public class ClienteRepositoryTest
    {

        private IClienteRepository clienteRepository { get; set; }

        public ClienteRepositoryTest()
        {
            clienteRepository = new ClienteRepository();
        }

        [Fact]
        public void TestaCadastroCliente()
        {
            Cliente clienteASerCadastrado = new Cliente();
            clienteASerCadastrado.Nome = "Cliente teste";
            clienteASerCadastrado.Email = "test@email.com";

            Cliente clienteCadastrado;

            var validacaoEmail = clienteRepository.BuscarPorEmail(clienteASerCadastrado.Email);

            if (validacaoEmail == null)
            {
                // se cliente não existir, testar cadastro inicial
                clienteCadastrado = clienteRepository.CadastrarCliente(clienteASerCadastrado);
                Assert.NotNull(clienteCadastrado);
            } else
            {
                //se cliente ja existir, verifica se o metodo lança uma exceção ao cadastrar email repetido 
                Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => clienteRepository.CadastrarCliente(clienteASerCadastrado));
                Assert.NotNull(validacaoEmail);
            }

        }
    }
}
