using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using Locadora.WebApi.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        public Filme CadastrarFilme(Filme filme)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                context.Add(filme);
                context.SaveChanges();
                return filme;
            }
        }

        public List<Filme> ListarFilmes()
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                List<Filme> filmes = context.Filmes.ToList();
                return filmes;
            }
        }
    }
}
