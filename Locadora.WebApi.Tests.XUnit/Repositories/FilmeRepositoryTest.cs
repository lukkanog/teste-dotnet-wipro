using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Locadora.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Locadora.WebApi.Tests.XUnit.Repositories
{
    public class FilmeRepositoryTest
    {
        private IFilmeRepository filmeRepository { get; set; }

        public FilmeRepositoryTest()
        {
            filmeRepository = new FilmeRepository();
        }

        [Fact]
        public void TestaListagemFilmes()
        {
            List<Filme> filmes = filmeRepository.ListarFilmes();
            Assert.NotNull(filmes);
        }

        [Fact]
        public void TestaCadastroFilme()
        {
            Filme filme = new Filme();
            filme.Nome = "Filme Teste";

            Filme filmeCadastrado = filmeRepository.CadastrarFilme(filme);
            Assert.NotNull(filmeCadastrado);
            Assert.Equal(filme, filmeCadastrado);
        }


    }
}
