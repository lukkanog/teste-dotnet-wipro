﻿using Locadora.WebApi.Contexts;
using Locadora.WebApi.Interfaces;
using Locadora.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void CadastrarCliente(Cliente cliente)
        {
            using (LocadoraContext context = new LocadoraContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }
    }
}
