using Locadora.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastra um novo filme no banco de dados.
        /// </summary>
        /// <param name="filme">Filme a ser cadastrado no banco de dados.</param>
        public Filme CadastrarFilme(Filme filme);

        /// <summary>
        /// Lista todos os filmes presentes no banco de dados.
        /// </summary>
        /// <returns>Lista de filmes</returns>
        public List<Filme> ListarFilmes();
    }
}
