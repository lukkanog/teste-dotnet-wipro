using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Locadora.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Locadora.WebApi.Tests.XUnit.Repositories
{
    public class LocacaoRepositoryTest
    {
        private ILocacaoRepository locacaoRepository { get; set; }

        public LocacaoRepositoryTest()
        {
            locacaoRepository = new LocacaoRepository();
        }

        [Fact]
        public void TestaListagemLocacoes()
        {
            List<Locacao> locacoes = locacaoRepository.Listar();
            Assert.NotNull(locacoes);
        }

        [Fact]
        public void TestaListagemLocacoesPorFilme()
        {
            Locacao locacao = locacaoRepository.Listar().FirstOrDefault() ;

            List<Locacao> locacoes = locacaoRepository.ListarPorFIlme(locacao.IdFilme);

            Assert.NotNull(locacoes);
            Assert.NotEmpty(locacoes);
        }

        [Fact]
        public void TestaListagemLocacoesPorCliente()
        {
            Locacao locacao = locacaoRepository.Listar().FirstOrDefault();

            List<Locacao> locacoes = locacaoRepository.ListarPorFIlme(locacao.IdCliente);

            Assert.NotNull(locacoes);
            Assert.NotEmpty(locacoes);
        }

    }
}
