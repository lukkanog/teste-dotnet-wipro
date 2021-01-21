using Locadora.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Interfaces
{
    public interface IClienteRepository
    {
        /// <summary>
        /// Cadastra um novo cliente e o salva no banco de dados.
        /// </summary>
        /// <param name="cliente">Cliente a ser cadastrado no banco de dados</param>
        public void CadastrarCliente(Cliente cliente);

        /// <summary>
        /// Busca um cliente no banco de dados através do endereço de email
        /// </summary>
        /// <param name="email">Email buscado</param>
        /// <returns>Usuário encontrado</returns>
        public Cliente BuscarPorEmail(string email);
    }
}
