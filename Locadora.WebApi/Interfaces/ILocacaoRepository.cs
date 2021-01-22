using Locadora.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Interfaces
{
    public interface ILocacaoRepository
    {
        /// <summary>
        /// Cadastra uma nova locação no banco de dados
        /// </summary>
        /// <param name="locacao">Locacao a ser cadastrada.</param>
        public Locacao CadastrarLocacao(Locacao locacao);

        /// <summary>
        /// Atualiza o registro no banco de dados, finalizando a locação.
        /// </summary>
        /// <param name="idLocacao">Id da locação a ser finalizada</param>
        public Locacao FinalizarLocacao(int idLocacao);

        /// <summary>
        /// Busca uma locação pelo id da mesma.
        /// </summary>
        /// <param name="idLocacao">Id de locação buscado.</param>
        /// <returns></returns>
        public Locacao BuscarPorId(int idLocacao);

        /// <summary>
        /// Lista todas as locações.
        /// </summary>
        /// <returns>Lista de todas as locações</returns>
        public List<Locacao> Listar();

        /// <summary>
        /// Lista todas as locações de determinado cliente.
        /// </summary>
        /// <param name="idUsuario">Id do cliente buscado</param>
        /// <returns>Lista de locações do usuário buscado</returns>
        public List<Locacao> ListarPorUsuario(int idUsuario);

        /// <summary>
        /// Lista todas as locações de determinado filme.
        /// </summary>
        /// <param name="idFilme">Id do filme buscado</param>
        /// <returns>Lista de locações do filme buscado</returns>

        public List<Locacao> ListarPorFIlme(int idFilme);
    }
}
