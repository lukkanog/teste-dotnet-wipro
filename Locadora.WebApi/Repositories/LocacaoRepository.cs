using Locadora.WebApi.Contexts;
using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
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
                Locacao locacaoBuscada = context.Locacoes.Find(idLocacao);

                if (locacaoBuscada == null)
                    throw new Exception("Locação não encontrada");

                return locacaoBuscada;
            }
        }

        public void CadastrarLocacao(Locacao locacao)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                Locacao locacaoBuscada = context.Locacoes.Where(x => x.IdFilme == locacao.IdFilme).ToList().LastOrDefault();

                if (locacaoBuscada != null && locacaoBuscada.DataRetorno == null)
                    throw new Exception("Filme indisponível");



                locacao.DataLocacao = DateTime.Now;

                context.Locacoes.Add(locacao);
                context.SaveChanges();
            }
        }

        public Locacao FinalizarLocacao(int idLocacao)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                Locacao locacaoBuscada = context.Locacoes.Find(idLocacao);

                if (locacaoBuscada == null)
                    throw new Exception("Locação não encontrada");

                if (locacaoBuscada.DataRetorno.HasValue)
                    throw new Exception("Esse filme já foi devolvido por essa pessoa.");
                

                locacaoBuscada.DataRetorno = DateTime.Now;

                locacaoBuscada.DiasAtrasado = locacaoBuscada.DataRetorno.Value.Date - locacaoBuscada.DataEsperada.Date;

                context.Update(locacaoBuscada);
                context.SaveChanges();

                return locacaoBuscada;
            }
        }

        public List<Locacao> Listar()
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes.ToList();
                return locacoes;
            }
        }

        public List<Locacao> ListarPorFIlme(int idFilme)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes.Where(x => x.IdFilme == idFilme).ToList();
                return locacoes;
            }
        }

        public List<Locacao> ListarPorUsuario(int idUsuario)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Locacao> locacoes = context.Locacoes.Where(x => x.IdCliente == idUsuario).ToList();
                return locacoes;
            }
        }
    }
}
