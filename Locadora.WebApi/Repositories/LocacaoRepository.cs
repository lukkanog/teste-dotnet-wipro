using Locadora.WebApi.Contexts;
using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        public Locacao BuscarPorId(int idLocacao)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                Locacao locacaoBuscada = context.Locacoes
                     .Include(x => x.Filme)
                     .Include(x => x.Cliente)
                     .FirstOrDefault(x => x.IdLocacao == idLocacao);

                // Verifica se locação não existe
                if (locacaoBuscada == null)
                    throw new Exception("Locação não encontrada");

                return locacaoBuscada;
            }
        }

        public Locacao CadastrarLocacao(Locacao locacao)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                Locacao locacaoBuscada = context.Locacoes
                    .Where(x => x.IdFilme == locacao.IdFilme)
                    .ToList()
                    .LastOrDefault();

                // Verifica se o filme está atualmente alugado (indisponível)
                if (locacaoBuscada != null && locacaoBuscada.DataRetorno == null)
                    throw new Exception("Filme indisponível");



                locacao.DataLocacao = DateTime.Now;

                context.Locacoes.Add(locacao);
                context.SaveChanges();
                return locacao;
            }
        }

        public Locacao FinalizarLocacao(int idLocacao)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                Locacao locacaoBuscada = context.Locacoes
                    .Include(x => x.Filme)
                    .Include(x => x.Cliente)
                    .FirstOrDefault(x => x.IdLocacao == idLocacao);


                // Verifica se a locação não existe
                if (locacaoBuscada == null)
                    throw new Exception("Locação não encontrada");

                // Verifica se a locação já foi finalizada
                if (locacaoBuscada.DataRetorno.HasValue)
                    throw new Exception("Esse filme já foi devolvido por essa pessoa.");
                

                locacaoBuscada.DataRetorno = DateTime.Now;

                // Calcula diferença de dias entre a data esperada e a data de retorno.
                locacaoBuscada.DiasAtrasado = locacaoBuscada.DataRetorno.Value.Date - locacaoBuscada.DataEsperada.Date;

                context.Update(locacaoBuscada);
                context.SaveChanges();

                // Para evitar loopings no retorno, define as locações como nulas.
                locacaoBuscada.Filme.Locacoes = null;
                locacaoBuscada.Cliente.Locacoes = null;

                return locacaoBuscada;
            }
        }

        public List<Locacao> Listar()
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes
                    .Include(x => x.Filme)
                    .Include(x => x.Cliente)
                    .ToList();

                // Para evitar loopings no retorno, define as locações de cada filme e cliente como nulas.
                foreach (var item in locacoes)
                {
                    item.Cliente.Locacoes = null;
                    item.Filme.Locacoes = null;
                }

                return locacoes;
            }
        }

        public List<Locacao> ListarPorFIlme(int idFilme)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes
                    .Where(x => x.IdFilme == idFilme)
                    .Include(x => x.Cliente)
                    .ToList();

                // Para evitar loopings no retorno, define as locações de cada cliente como nulas.
                foreach (var item in locacoes)
                {
                    item.Cliente.Locacoes = null;
                }

                return locacoes;
            }
        }

        public List<Locacao> ListarPorUsuario(int idUsuario)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes
                    .Where(x => x.IdCliente == idUsuario)
                    .Include(x => x.Filme)
                    .ToList();

                // Para evitar loopings no retorno, define as locações de cada filme como nulas.
                foreach (var item in locacoes)
                {
                    item.Filme.Locacoes = null;
                }

                return locacoes;
            }
        }
    }
}
